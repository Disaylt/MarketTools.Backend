﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Autoresponder
{
    public class AutoresponderResultModel
    {
        public string? Text { get; set; }
        public required string Report { get; set; }
        public bool IsSuccess { get; set; }
    }
}
