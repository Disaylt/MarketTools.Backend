using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderBlackList : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public List<StandardAutoresponderBanWord> BanWords { get; set; } = new List<StandardAutoresponderBanWord>();
    }
}
