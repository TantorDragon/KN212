using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Bakery.Api.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpireMinutes { get; set; }

        public SymmetricSecurityKey SecretKey { get; set; } = GenerateKey();

        public string SecurityAlgorithm { get; set; }

        private static SymmetricSecurityKey GenerateKey()
        {
            var key = new byte[64];
            using var generator = RandomNumberGenerator.Create();
            generator.GetBytes(key);
            var base64Secret = Convert.ToBase64String(key).TrimEnd('=').Replace('+', '-').Replace('/', '_');
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(base64Secret));
        }
    }
}
