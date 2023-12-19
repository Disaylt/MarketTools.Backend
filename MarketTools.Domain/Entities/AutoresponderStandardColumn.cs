using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderStandardColumn : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public AutoresponderColumnType Type { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public List<AutoresponderStandardCell> Cells { get; set; } = new List<AutoresponderStandardCell>();
        public List<AutoresponderStandardColumnBindPosition> BindPositions { get; set; } = new List<AutoresponderStandardColumnBindPosition>();
    }
}
