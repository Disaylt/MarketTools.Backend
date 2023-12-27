﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderConnection
    {
        public bool IsActive { get; set; }

        [Key]
        public int SellerConnectionId { get; set; }
        public SellerConnection SellerConnection { get; set; } = null!;

        public List<StandardAutoresponderConnectionRating> Ratings { get; set; } = new List<StandardAutoresponderConnectionRating>();
    }
}