using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Autoresponder.Standard
{
    public class ReportCreateDto
    {
        public int Rating { get; set; }
        public DateTime ReviewCreateDate { get; set; }
        public int Article { get; set; }
        public string SupplierArticle { get; set; } = "-";
        public string Response { get; set; } = string.Empty;
        public string Report { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
        public int ConnectionId { get; set; }
    }
}
