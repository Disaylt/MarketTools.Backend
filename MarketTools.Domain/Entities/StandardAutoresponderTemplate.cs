using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderTemplate : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public StandardAutoresponderTemplateSettings Settings { get; set; } = new StandardAutoresponderTemplateSettings();

        public List<StandardAutoresponderTemplateArticle> Articles { get; set; } = new List<StandardAutoresponderTemplateArticle>();
        public List<StandardAutoresponderColumnBindPosition> BindPositions { get; set; } = new List<StandardAutoresponderColumnBindPosition>();
        public List<StandardAutoresponderConnectionRating> Ratings { get; set; } = new List<StandardAutoresponderConnectionRating>();
    }
}
