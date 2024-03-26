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
        [MaxLength(1000)]
        public string Name { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public AppIdentityUser User { get; set; } = null!;

        public int? BlackListId { get; set; }
        public StandardAutoresponderBlackListEntity? BlackList { get; set; }

        public StandardAutoresponderTemplateSettingsEntity Settings { get; set; } = new StandardAutoresponderTemplateSettingsEntity();

        public List<StandardAutoresponderTemplateArticleEntity> Articles { get; set; } = new List<StandardAutoresponderTemplateArticleEntity>();
        public List<StandardAutoresponderBindPositionEntity> BindPositions { get; set; } = new List<StandardAutoresponderBindPositionEntity>();
        public List<StandardAutoresponderConnectionRatingEntity> Ratings { get; set; } = new List<StandardAutoresponderConnectionRatingEntity>();
    }
}
