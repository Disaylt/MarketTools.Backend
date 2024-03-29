﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Domain.Entities
{
    public class StandardAutoresponderConnectionEntity
    {
        public bool IsActive { get; set; }

        [Key]
        public int SellerConnectionId { get; set; }
        public MarketplaceConnectionEntity SellerConnection { get; set; } = null!;

        public List<StandardAutoresponderConnectionRatingEntity> Ratings { get; set; } = new List<StandardAutoresponderConnectionRatingEntity>();
        public List<StandardAutoresponderNotificationEntity> Notifications { get; set; } = new List<StandardAutoresponderNotificationEntity>();
    }
}
