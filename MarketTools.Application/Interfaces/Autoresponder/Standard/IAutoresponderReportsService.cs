using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderReportsService
    {
        public Task<StandardAutoresponderNotificationEntity> AddAsync(FeedbackDto feedback, AutoresponderResultModel answer, int connectionId, bool isUseCommit = false);
    }
}
