using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Interfaces.Requests
{
    public interface IHttpConnectionContextCall
    {
        public int ConnectionId { get; set; }
    }
}
