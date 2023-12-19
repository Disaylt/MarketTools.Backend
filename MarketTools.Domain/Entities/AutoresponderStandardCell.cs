using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderStandardCell : BaseEntity
    {
        [MaxLength(1000)]
        public string Value { get; set; } = null!;

        public int ColumnId { get; set; }
        public AutoresponderStandardColumn Column { get; set; } = null!;
    }
}
