using PharmacyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PharmacyProject.Controllers;

public class AuthController : Controller
{
    private readonly IPatientService _patientService;
    private readonly IDiscountService _discountService;
    public AuthController(IPatientService patientService, IDiscountService discountService)
	{
        _patientService = patientService;
        _discountService = discountService;
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

