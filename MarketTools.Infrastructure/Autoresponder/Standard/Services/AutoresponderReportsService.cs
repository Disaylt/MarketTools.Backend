using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class AutoresponderReportsService(IUnitOfWork _unitOfWork)
        : IAutoresponderReportsService
    {
        private readonly IRepository<StandardAutoresponderNotificationEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderNotificationEntity>();

        public async Task<StandardAutoresponderNotificationEntity> AddAsync(FeedbackDetails feedback, AutoresponderResultModel answer, int connectionId, bool isUseCommit = false)
        {
            StandardAutoresponderNotificationEntity entity = Create(feedback, answer, connectionId);
            await _repository.AddAsync(entity);
            await _unitOfWork.UseCommit(isUseCommit);

            return entity;
        }

        private StandardAutoresponderNotificationEntity Create(FeedbackDetails feedback, AutoresponderResultModel answer, int connectionId)
        {
            return new StandardAutoresponderNotificationEntity
            {
                Article = feedback.ProductDetails.ImtId,
                SupplierArticle = feedback.ProductDetails.SupplierArticle,
                StandardAutoresponderConnectionId = connectionId,
                IsSuccess = answer.IsSuccess,
                Rating = feedback.ProductValuation,
                Report = answer.Report,
                Response = answer.Text ?? "-",
                ReviewCreateDate = feedback.CreatedDate
            };
        }
    }
}
