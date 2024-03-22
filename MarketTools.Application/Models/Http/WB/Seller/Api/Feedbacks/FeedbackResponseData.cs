using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Models.Http.WB.Seller.Api.Feedbacks
{
    public class FeedbackResponseData
    {
        public int CountUnanswered { get; set; }
        public int CountArchive { get; set; }
        public List<FeedbackDetails> Feedbacks { get; set; } = new List<FeedbackDetails>();
    }
}
