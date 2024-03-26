using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderBlackListEntity : BaseEntity
    {
        [MaxLength(1000)]
        [Required]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public List<StandardAutoresponderBanWordEntity> BanWords { get; set; } = new List<StandardAutoresponderBanWordEntity>();
        public List<StandardAutoresponderTemplateEntity> Templates { get; set; } = new List<StandardAutoresponderTemplateEntity>();
    }
}
