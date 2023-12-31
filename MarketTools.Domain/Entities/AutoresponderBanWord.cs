﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class AutoresponderBanWord : BaseEntity
    {
        [MaxLength(100)]
        public string Value { get; set; } = null!;

        public int BlackListId { get; set; }
        public AutoresponderBlackList BlackList { get; set; } = null!;
    }
}
