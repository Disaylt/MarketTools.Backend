using MarketTools.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Identity
{
    public class IdentityContext : IContext
    {
        public required string UserId { get; set; }
    }
}
