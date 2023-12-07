using MarketTools.Application.Common.Configuration;
using MarketTools.Application.Interfaces.Identity;
using Microsoft.AspNetCore.DataProtection;
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
            DateTime expires = GetExpireDate();
            List<Claim> claims = CreateClaims(user);
            SigningCredentials signingCredentials = CreateSigningCredentials();

            JwtSecurityToken jwtSecurityToken = new(
                _sequreSettings.Value.Jwt.ValidIssuer,
                _sequreSettings.Value.Jwt.ValidAudience,
                claims,
                expires: expires,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);
        }

        private SigningCredentials CreateSigningCredentials()
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(_sequreSettings.Value.Jwt.Secret);
            SymmetricSecurityKey authSigningKey = new SymmetricSecurityKey(secretBytes);

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
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!)
            };
        }
    }
}
