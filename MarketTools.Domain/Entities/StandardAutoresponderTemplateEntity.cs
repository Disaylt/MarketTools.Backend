using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderTemplateEntity : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public int? BindAutoresponerBlackListId { get; set; }
        public StandardAutoresponderBlackListEntity? BindAutoresponerBlackList { get; set; }

        public StandardAutoresponderTemplateSettingsEntity Settings { get; set; } = new StandardAutoresponderTemplateSettingsEntity();

        public List<StandardAutoresponderTemplateArticleEntity> Articles { get; set; } = new List<StandardAutoresponderTemplateArticleEntity>();
        public List<StandardAutoresponderColumnBindPositionEntity> BindPositions { get; set; } = new List<StandardAutoresponderColumnBindPositionEntity>();
        public List<StandardAutoresponderConnectionRatingEntity> Ratings { get; set; } = new List<StandardAutoresponderConnectionRatingEntity>();
    }
}
