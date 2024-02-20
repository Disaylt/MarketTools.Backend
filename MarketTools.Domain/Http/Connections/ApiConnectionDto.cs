using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Http.Connections
{
    public class ApiConnectionDto : AbstractConnection
    {
        public required string Token { get; set; }
    }
}
