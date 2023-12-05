using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderTemplate : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public AutoresponderTemplateSettings Settings { get; set; } = new AutoresponderTemplateSettings();

        public List<AutoresponderTemplateArticle> Articles { get; set; } = new List<AutoresponderTemplateArticle>();
        public List<AutoresponderColumnBindPosition> BindPositions { get; set; } = new List<AutoresponderColumnBindPosition>();
        public List<AutoresponderConnectionRating> Ratings { get; set; } = new List<AutoresponderConnectionRating>();
    }
}
