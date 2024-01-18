using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    [Index(nameof(TemplateId), nameof(Value), IsUnique = true, Name = "UniqueArticlesIndex")]
    public class StandardAutoresponderTemplateArticleEntity : BaseEntity
    {
        [MaxLength(50)]
        public string Value { get; set; } = null!;

        public int TemplateId { get; set; }
        public StandardAutoresponderTemplateEntity Template { get; set; } = null!;
    }
}
