using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Models
{
    public abstract class AddBaseCommand
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
