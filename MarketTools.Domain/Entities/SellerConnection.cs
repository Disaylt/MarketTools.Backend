using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class SellerConnection : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public AutoresponderConnection AutoresponderConnection { get; set; } = new AutoresponderConnection();
    }
}
