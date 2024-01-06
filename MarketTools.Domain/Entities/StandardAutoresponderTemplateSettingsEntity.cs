using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderTemplateSettingsEntity
    {
        [Key]
        public int TemplateId { get; set; }
        public StandardAutoresponderTemplateEntity Template { get; set; } = null!;

        public bool IsSkipWithTextFeedbacks { get; set; }
        public bool IsSkipEmptyFeedbacks { get; set; }
        public bool AsMainTemplate { get; set; }
    }
}
