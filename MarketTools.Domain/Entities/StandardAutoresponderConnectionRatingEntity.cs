using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    [PrimaryKey(nameof(Rating), nameof(ConnectionId))]
    public class StandardAutoresponderConnectionRatingEntity
    {
        [Range(1,5, ErrorMessage = "Диапазон оценки от 1 до 5")]
        public int Rating { get; set; }
        public int ConnectionId { get; set; }
        public StandardAutoresponderConnectionEntity Connection { get; set; } = null!;

        public List<StandardAutoresponderTemplateEntity> Templates { get; set; } = new List<StandardAutoresponderTemplateEntity>();
    }
}
