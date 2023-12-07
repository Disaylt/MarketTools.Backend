using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderColumnBindPosition
    {
        public int Position { get; set; }
        public int TemplateId { get; set; }
        public AutoresponderTemplate Template { get; set; } = null!;

        public int? ColumnId { get; set; }
        public AutoresponderColumn? Column { get; set; }
    }
}
