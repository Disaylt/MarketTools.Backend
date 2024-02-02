using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http.Wb.Seller.Api
{
    public interface IFeedbacksHttpService
    {
        public Task SendResponse(string text);
    }
}
