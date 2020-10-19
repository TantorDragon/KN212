using Microsoft.IdentityModel.Tokens;

namespace Bakery.Api.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpireMinutes { get; set; }

        public SymmetricSecurityKey SecretKey { get; set; }

        public string SecurityAlgorithm { get; set; }
    }
}
