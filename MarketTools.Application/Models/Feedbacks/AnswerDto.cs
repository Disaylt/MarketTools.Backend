using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Feedbacks
{
    public class AnswerDto
    {
        public required string FeedbackId { get; set; }
        public required string Text { get; set; }
    }
}
