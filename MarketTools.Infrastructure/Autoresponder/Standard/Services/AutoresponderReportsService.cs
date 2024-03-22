﻿using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Feedbacks;
using MarketTools.Application.Models.Http.WB.Seller;
using MarketTools.Domain.Entities;
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

        public async Task<StandardAutoresponderNotificationEntity> AddAsync(FeedbackDto feedback, AutoresponderResultModel answer, int connectionId)
        {
            StandardAutoresponderNotificationEntity entity = Create(feedback, answer, connectionId);
            await _repository.AddAsync(entity);

            return entity;
        }

        private StandardAutoresponderNotificationEntity Create(FeedbackDto feedback, AutoresponderResultModel answer, int connectionId)
        {
            return new StandardAutoresponderNotificationEntity
            {
                Article = feedback.ProductDetails.Article,
                SupplierArticle = feedback.ProductDetails.SellerArticle,
                StandardAutoresponderConnectionId = connectionId,
                IsSuccess = answer.IsSuccess,
                Rating = feedback.Grade,
                Report = answer.Report,
                Response = answer.Text ?? "-",
                ReviewCreateDate = feedback.CreatedDate
            };
        }
    }
}
