using System.Security.Claims;

namespace PharmacyProject.Domain.Models;


public class AuthenticationResult
{
    public bool Success { get; set; }
    public ClaimsIdentity? ClaimsIdentity { get; set; }
    public string? ErrorMessage { get; set; }

}


