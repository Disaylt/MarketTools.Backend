using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
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

        public async Task<StandardAutoresponderNotificationEntity> AddWithoutAsyncAsync(bool isSuccess, string report, string response, int connectionId)
        {
            StandardAutoresponderNotificationEntity entity = new StandardAutoresponderNotificationEntity
            {
                StandardAutoresponderConnectionId = connectionId,
                IsSuccess = isSuccess,
                Report = report,
                Response = response
            };

            await _repository.AddAsync(entity);

            return entity;
        }
    }
}
