﻿using Microsoft.IdentityModel.Tokens;

namespace Bakery.Api.Authentication
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int ExpireMinutes { get; set; }

        public SymmetricSecurityKey SecretKey { get; set; } = 
            new SymmetricSecurityKey(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 7, 6, 5, 4, 3, 2, 1 });

        public string SecurityAlgorithm { get; set; }
    }
}