using Bakery.Api.Authentication;
using Bakery.Core.Models;
using Bakery.Core.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _repository;
        private readonly JwtOptions _jwtOptions;
        public AuthService(IRepository<User> repository, JwtOptions jwtOptions)
        {
            (_repository, _jwtOptions) = (repository, jwtOptions);
        }
        public async Task<string> GetToken(string login, string password)
        {
            if (string.IsNullOrEmpty(password.Trim()) || string.IsNullOrEmpty(login.Trim()))
            {
                return null;
            }

            var identity = (await _repository.GetByPropertiesAsync(u => u.Login == login && u.Password == password)).FirstOrDefault();

            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: _jwtOptions.Issuer,
                    audience: _jwtOptions.Audience,
                    notBefore: now,
                    expires: now.Add(TimeSpan.FromMinutes(_jwtOptions.ExpireMinutes)),
                    signingCredentials: new SigningCredentials(_jwtOptions.SecretKey, _jwtOptions.SecurityAlgorithm));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
