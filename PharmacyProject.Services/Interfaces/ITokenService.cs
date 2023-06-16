using System;
namespace PharmacyProject.Services.Interfaces
{
	public interface ITokenService
	{
		public string GenerateToken(string email, string password);
		public bool ValidateToken(string token);
		public Task<bool> AuthenticateUser(string email, string password);

    }
}

