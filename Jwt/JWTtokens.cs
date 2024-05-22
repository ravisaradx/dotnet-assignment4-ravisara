using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApplication2.Jwt
{
    public class JWTtokens
    {
        private readonly string _secret;
        private readonly string _issuer;
        private readonly string _audience;

        public JWTtokens(string secret, string issuer, string audience)
        {
            _secret = secret;
            _issuer = issuer;
            _audience = audience;
        }

        public string GenerateToken(string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _audience),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_issuer, _audience, claims, expires: DateTime.UtcNow.AddHours(2), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
