using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderColumnBindPositionEntity
    {
        public int Position { get; set; }
        public int TemplateId { get; set; }
        public StandardAutoresponderTemplateEntity Template { get; set; } = null!;

        public int? ColumnId { get; set; }
        public StandardAutoresponderColumnEntity? Column { get; set; }
    }
}
