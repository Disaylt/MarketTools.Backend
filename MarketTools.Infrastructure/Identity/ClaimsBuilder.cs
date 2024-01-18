using Microsoft.AspNetCore.Identity;
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
    internal class ClaimsBuilder
    {
        private readonly List<Claim> _claims = new List<Claim>();
        private readonly IdentityUser _user;

        public ClaimsBuilder(IdentityUser user)
        {
            _user = user;
            _claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            _claims.Add(new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64));
            _claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            _claims.Add(new Claim(ClaimTypes.Name, user.UserName!));
            _claims.Add(new Claim(ClaimTypes.Email, user.Email!));
        }

        public ClaimsBuilder AddRole(string role, IEnumerable<string> roleUsers)
        {
            if (roleUsers
                .Select(x => x.ToUpper())
                .Contains(_user.NormalizedUserName))
            {
                _claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return this;
        }

        public IEnumerable<Claim> Build()
        {
            return _claims;
        }
    }
}
