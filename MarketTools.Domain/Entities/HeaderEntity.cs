using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class HeaderEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Value { get; set; } = null!;
    }
}
