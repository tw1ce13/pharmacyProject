using PharmacyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Domain.Models;

namespace PharmacyProject.Controllers;

public class DrugsController : Controller
{
    private readonly IDrugService _drugService;
    private readonly IAvailabilityService _availabilityService;
    private readonly IDeliveryService _deliveryService;
    private readonly IClassService _classService;
    private readonly IPatientService _patientService;
    private readonly IOrderService _orderService;
    private readonly IOrdDrugService _ordDrugService;

    public DrugsController(IOrdDrugService ordDrugService, IOrderService orderService, IPatientService patientService, IDrugService drugService, IAvailabilityService availabilityService, IDeliveryService deliveryService, IClassService classService)
	{
        _availabilityService = availabilityService;
        _deliveryService = deliveryService;
        _classService = classService;
        _drugService = drugService;
        _ordDrugService = ordDrugService;
        _orderService = orderService;
        _patientService = patientService;
	}


    public async Task<ActionResult> GetDrugs(int pharmacyId, CancellationToken cancellationToken)
    {
        HttpContext.Session.SetInt32("PharmacyId", pharmacyId);

        var baseResponseDrug = await _drugService.GetAll(cancellationToken);
        var baseResponseAvailability = await _availabilityService.GetAvailabilitiesByPharmacyId(pharmacyId);
        var baseResponseDelivery = await _deliveryService.GetFresh();
        var baseResponseAvailabilityFresh = await _availabilityService.GetAvailabilitiesByDelivery(baseResponseDelivery.Data.Select(x => x.Id));
        var baseResponseClass = await _classService.GetAll();
        var availabilities = from availability in baseResponseAvailability.Data
                             join avail in baseResponseAvailabilityFresh.Data on new { availability.PharmacyId, availability.DeliveryId }
                             equals new { avail.PharmacyId, avail.DeliveryId }
                             select availability;
        var drugs = await _drugService.GetDrugs(availabilities, baseResponseClass.Data, baseResponseDelivery.Data);

        return View(drugs.Data);
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
            return RedirectToAction("GetDrugs", "Drugs", new { pharmacyId = pharmacyId, token });
        }
        return RedirectToAction("Register", "Auth");
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
}

