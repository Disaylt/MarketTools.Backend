using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderColumnEntity : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Range(1, 999)]
        public AutoresponderColumnType Type { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public List<StandardAutoresponderCell> Cells { get; set; } = new List<StandardAutoresponderCell>();
        public List<StandardAutoresponderBindPositionEntity> BindPositions { get; set; } = new List<StandardAutoresponderBindPositionEntity>();
    }
}
