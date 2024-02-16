using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderReportsService
    {
        public Task<StandardAutoresponderNotificationEntity> AddAsync(FeedbackDetails feedback, AutoresponderResultModel answer, int connectionId, bool isUseCommit = false);
    }
}
