using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderStandardTemplate : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public AutoresponderStandardTemplateSettings Settings { get; set; } = new AutoresponderStandardTemplateSettings();

        public List<AutoresponderStandardTemplateArticle> Articles { get; set; } = new List<AutoresponderStandardTemplateArticle>();
        public List<AutoresponderStandardColumnBindPosition> BindPositions { get; set; } = new List<AutoresponderStandardColumnBindPosition>();
        public List<AutoresponderStandardConnectionRating> Ratings { get; set; } = new List<AutoresponderStandardConnectionRating>();
    }
}
