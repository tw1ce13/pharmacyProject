using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using PharmacyProject.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PharmacyProject.Controllers;

public class MainController : Controller
{
    private readonly IWebService _webService;
    private readonly IPharmacyService _pharmacyService;

    public MainController(IPharmacyService pharmacyService, IWebService webService)
    {
        _pharmacyService = pharmacyService;
        _webService = webService;
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


}

