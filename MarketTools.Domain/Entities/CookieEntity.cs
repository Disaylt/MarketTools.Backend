using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class CookieEntity : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(2000)]
        public string Value { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Path { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Domain { get; set; } = null!;
    }
}
