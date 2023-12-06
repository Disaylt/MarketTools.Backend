using MarketTools.Application.Common.Configuration;
using MarketTools.Application.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Identity
{
    internal class JwtTokenService(IOptions<SequreSettings> _sequreSettings) : ITokenService
    {
        public string Create(IdentityUser user)
        {
            JwtSecurityToken jwtSecurityToken = new(
                _sequreSettings.Value.Jwt.ValidIssuer,
                _sequreSettings.Value.Jwt.ValidAudience,
                CreateClaims(user),
                expires: GetExpireDate(),
                signingCredentials: CreateSigningCredentials());

            return new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
        }

        private SigningCredentials CreateSigningCredentials()
        {
            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_sequreSettings.Value.Jwt.Secret));

            return new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
        }

        private DateTime GetExpireDate()
        {
            return DateTime.UtcNow.AddDays(_sequreSettings.Value.Jwt.ExpireDay);
        }

        private List<Claim> CreateClaims(IdentityUser user)
        {
            return new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
        }
    }
}
