using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PharmacyProject.Domain
{
    public class AuthOptions
    {
        public const string issure = "MyAuthServer";
        public const string audience = "MyAuthClient";
        const string key = "SecurityKeyForToken";
        public const int lifetime = 100;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    }
}

