using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TesteTecnico.Application.Interfaces;
using TesteTecnico.Domain.Entities;

namespace TesteTecnico.Application.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public JwtTokenService(IConfiguration configuration,
            UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public string GenerateToken(User user)
        {
            IdentityOptions _options = new IdentityOptions();

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              issuer: _configuration["jwt:issuer"],
              audience: _configuration["jwt:issuer"],
              claims: claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
