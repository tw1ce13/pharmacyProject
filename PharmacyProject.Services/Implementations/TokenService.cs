using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PharmacyProject.DAL.Interfaces;
using PharmacyProject.DAL.Repositories;
using PharmacyProject.Domain;
using PharmacyProject.Domain.Models;
using PharmacyProject.Services.Interfaces;

namespace PharmacyProject.Services.Implementations
{
	public class TokenService : ITokenService
	{
        private readonly IBaseRepository<Patient> _patientRepository;

        public TokenService(IBaseRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public string GenerateToken(string email, string password)
        {
            var claims = new[]
            {
                new Claim("email", email)
            };

            var credentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.lifetime)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
            
        }

        public bool ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuer = true,
                ValidateAudience = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            return true;

        }

        public async Task<bool> AuthenticateUser(string email, string password)
        {
            var users = await _patientRepository.GetAll();
            var user = users.Where(p => p.Email == email).First();
            if (user != null && VerifyPassword(user.Password, password))
                return true;
            return false;
        }

        private bool VerifyPassword(string userPassword, string password)
        {
            return password == userPassword;
        }
    }
}

