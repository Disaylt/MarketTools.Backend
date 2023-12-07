using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Identity
{
    public interface ITokenService
    {
        public string Create(IdentityUser user);
    }
}
