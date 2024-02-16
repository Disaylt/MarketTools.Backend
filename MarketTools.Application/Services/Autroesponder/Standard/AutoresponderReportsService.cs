using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.WB.Seller.Api.Feedbaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Autroesponder.Standard
{
    internal class AutoresponderReportsService(IUnitOfWork _unitOfWork)
        : IAutoresponderReportsService
    {
        private readonly IRepository<StandardAutoresponderNotificationEntity> _repository = _unitOfWork.GetRepository<StandardAutoresponderNotificationEntity>();

        public Task<StandardAutoresponderNotificationEntity> AddAsync(FeedbackDetails feedback, AutoresponderResultModel answer)
        {
            throw new NotImplementedException();
        }

        private StandardAutoresponderNotificationEntity Create(ReportCreateDto model)
        {
            return new StandardAutoresponderNotificationEntity
            {
                StandardAutoresponderConnectionId = model.ConnectionId,
                IsSuccess = model.IsSuccess,
                Report = model.Report,
                Response = model.Response,
                Article = model.Article,
                SupplierArticle = model.SupplierArticle,
                Rating = model.Rating,
                ReviewCreateDate = model.ReviewCreateDate
            };
        }
    }
}
