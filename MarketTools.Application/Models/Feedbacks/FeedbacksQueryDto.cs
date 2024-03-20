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
        public List<FeedbacksType> Types { get; } = new List<FeedbacksType>();
        public required int Take { get; set; }
        public required int Skip { get; set; }
        public List<int> Grades { get; } = new List<int>();
        public OrderType Order { get; set; }
        public string? Article { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    public enum FeedbacksType
    {
        New,
        Viewed
    }
}
