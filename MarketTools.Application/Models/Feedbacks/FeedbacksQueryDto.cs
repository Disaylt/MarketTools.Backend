using AutoMapper;
using MarketTools.Application.Interfaces.Mapping;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Feedbacks
{
    public class FeedbacksQueryDto
    {
        public required bool IsAnswered { get; set; }
        public required int Take { get; set; }
        public required int Skip { get; set; }
        public int? Grade { get; set; }
        public OrderType Order { get; set; }
        public string? Article { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
