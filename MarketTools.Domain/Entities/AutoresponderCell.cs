﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderCell : BaseEntity
    {
        [MaxLength(1000)]
        public string Value { get; set; } = null!;

        public int ColumnId { get; set; }
        public AutoresponderColumn Column { get; set; } = null!;
    }
}
