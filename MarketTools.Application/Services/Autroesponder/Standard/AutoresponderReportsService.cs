using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
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

        public async Task<StandardAutoresponderNotificationEntity> AddWithoutAsyncAsync(ReportCreateDto model)
        {
            StandardAutoresponderNotificationEntity entity = new StandardAutoresponderNotificationEntity
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

            await _repository.AddAsync(entity);

            return entity;
        }
    }
}
