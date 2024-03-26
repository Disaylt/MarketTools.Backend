using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class PriceMonitoringProductRecordEntity : BaseEntity
    {
        [DefaultValue("Неизвестно")]
        public string Name { get; set; } = "Неизвестно";

        [Required]
        public string Article { get; set; } = null!;
        public string SellerArticle { get; set; } = "";

        public int ReportId { get; set; }
        public PriceMonitoringReportEntity Report { get; set; } = null!;
    }
}
