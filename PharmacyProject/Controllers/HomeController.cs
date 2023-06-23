﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using PharmacyProject.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PharmacyProject.Controllers;
public class HomeController : Controller
{
    private readonly IWebService _webService;
    private readonly IOrderService _orderService;
    private readonly IPharmacyService _pharmacyService;
    private readonly IDrugService _drugService;
    private readonly IAvailabilityService _availabilityService;
    private readonly IDeliveryService _deliveryService;
    private readonly IClassService _classService;
    private readonly IPatientService _patientService;
    private readonly IDiscountService _discountService;
    private readonly IOrdDrugService _ordDrugService;

    public HomeController(IOrdDrugService ordDrugService, IDiscountService discountService, IPatientService patientService, IClassService classService, IOrderService orderService, IPharmacyService pharmacyService, IWebService webService, IDrugService drugService, IAvailabilityService availabilityService, IDeliveryService deliveryService)
    {
        _classService = classService;
        _orderService = orderService;
        _pharmacyService = pharmacyService;
        _webService = webService;
        _drugService = drugService;
        _availabilityService = availabilityService;
        _deliveryService = deliveryService;
        _patientService = patientService;
        _discountService = discountService;
        _ordDrugService = ordDrugService;
    }
    
    public async Task<ActionResult> Index()
    {
        var baseResponse = await _webService.GetAll();
        var list = baseResponse.Data;
        return View(list);
    }

    [HttpGet]
    public async Task<ActionResult> GetPharmacyAddresses(int webId)
    {
        var baseResponsePharmacy = await _pharmacyService.GetAll();
        var pharmacies = baseResponsePharmacy.Data.Where(p => p.IdWeb == webId);
        return PartialView("_PharmacyAddressesPartialView", pharmacies);
    }

    public async Task<ActionResult> GetDrugs(int pharmacyId, CancellationToken cancellationToken)
    {
        HttpContext.Session.SetInt32("PharmacyId", pharmacyId);

        var baseResponseDrug = await _drugService.GetAll(cancellationToken);
        var baseResponseAvailability = await _availabilityService.GetAvailabilitiesByPharmacyId(pharmacyId);
        var baseResponseDelivery = await _deliveryService.GetFresh();
        var baseResponseAvailabilityFresh = await _availabilityService.GetAvailabilityByDelivery(baseResponseDelivery.Data.Select(x=>x.Id));
        var baseResponseClass = await _classService.GetAll();
        var availabilities = from availability in baseResponseAvailability.Data
                             join avail in baseResponseAvailabilityFresh.Data on new { availability.PharmacyId, availability.DeliveryId }
                             equals new { avail.PharmacyId, avail.DeliveryId }
                             select availability;
        var drugs = await _drugService.GetDrugs(availabilities, baseResponseClass.Data, baseResponseDelivery.Data);

        return View(drugs.Data);
    }

    public ActionResult Register()
    {
        return View();
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> ShowDiscounts()
    {
        var discounts = await _discountService.GetAll();
        return View(discounts.Data);
    }


    [HttpPost]
    public async Task<ActionResult> AddToOrder(int itemId, int quantity, CancellationToken token)
    {
        var patients = await _patientService.GetAll();
        var userId = patients.Data.Last().Id;
        HttpContext.Session.SetInt32("UserId", userId);
        Random random = new Random();
        int? pharmacyId = HttpContext.Session.GetInt32("PharmacyId");
        int employeeId = random.Next(7, 186);
        var date = DateTime.UtcNow;
        /*временное заполнение*/
        if (pharmacyId.HasValue)
        {
            Order order = new Order()
            {
                Date = DateTime.UtcNow,
                DiscountId = 5,
                PharmacyId = (int)pharmacyId,
                PatientId = userId,
                EmployeeId = employeeId
            };
            await _orderService.Add(order);

            var drug = await _drugService.Get(itemId, token);
            var orders = await _orderService.GetAll();
            var dataOrder = orders.Data.Last();
            var orderId = dataOrder.Id;
            /* временное заполнение*/
            OrdDrug ordDrug = new OrdDrug()
            {
                OrderId = orderId,
                DrugId = itemId,
                DiscountId = 5,
                Count = quantity,
                Price = quantity * drug.Data.Cost
            };
            await _ordDrugService.Add(ordDrug);
            return RedirectToAction("GetDrugs", "Home", new { pharmacyId = pharmacyId, token });
        }
        return RedirectToAction("Register", "Home");
    }

    public async Task<ActionResult> ShowItemsInOrder(CancellationToken cancellationToken)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var baseResponseDrug = await _drugService.GetAll(cancellationToken);
        var baseRespnseOrd = await _orderService.GetAll();
        var baseResponseOrdDrug = await _ordDrugService.GetAll();
        if (userId.HasValue)
        {
            var list = await _drugService.GetDrugInOrders(baseRespnseOrd.Data, baseResponseOrdDrug.Data, userId.Value);
            return View(list.Data);
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GenerateToken(string email, string password)
    {
        var identity = await AuthenticateUser(email, password);
        if (identity == null)
            return BadRequest(new { errorText = "Invalid username or password." });

        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.issure,
                    audience: AuthOptions.audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        var response = new
        {
            access_token = encodedJwt
        };

        return Json(response);
    }


    private async Task<ClaimsIdentity?> AuthenticateUser(string email, string password)
    {
        var users = await _patientService.GetAll();
        var user = users.Data.FirstOrDefault(p => p.Email == email && p.Password == password);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim("E-mail", email)
            };

            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
        return null;
    }
}

