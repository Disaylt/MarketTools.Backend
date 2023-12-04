using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
