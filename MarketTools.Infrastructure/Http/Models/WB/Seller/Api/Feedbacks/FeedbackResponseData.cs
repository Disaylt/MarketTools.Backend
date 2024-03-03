using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.Models.WB.Seller.Api.Feedbacls
{
    internal class FeedbackResponseData
    {
        public int CountUnanswered { get; set; }
        public int CountArchive { get; set; }
        public List<FeedbackDetails> Feedbacks { get; set; } = new List<FeedbackDetails>();
    }
}
