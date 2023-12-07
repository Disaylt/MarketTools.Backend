using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderTemplateArticle : BaseEntity
    {
        [MaxLength(50)]
        public string Article { get; set; } = null!;

        public int TemplateId { get; set; }
        public AutoresponderTemplate Template { get; set; } = null!;
    }
}
