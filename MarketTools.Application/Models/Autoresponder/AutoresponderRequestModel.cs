using MarketTools.Application.Interfaces.Common;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Autoresponder
{
    public class AutoresponderRequestModel
    {
        public required string Article { get; set; }
        public required string Text { get; set; }
        public int Rating { get; set; }
    }
}
