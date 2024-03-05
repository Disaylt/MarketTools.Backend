using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Models
{
    internal class CookieModel
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
        public required string Path { get; set; }
        public required string Domain { get; set; }
    }
}
