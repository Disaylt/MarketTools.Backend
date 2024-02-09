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
        public Task<StandardAutoresponderNotificationEntity> AddWithoutAsyncAsync(bool isSuccess, string report, string response, int connectionId);
    }
}
