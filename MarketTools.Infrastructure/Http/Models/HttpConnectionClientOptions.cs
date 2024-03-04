using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Models
{
    internal class HttpConnectionClientOptions
    {
        public bool IsThrowBadRequestexception { get; set; } = true;
    }
}
