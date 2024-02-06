using MarketTools.Application.Models.Autoresponder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public interface IAutoresponderResponseService
    {
        public AutoresponderResultModel Build(AutoresponderRequestModel request);
    }
}
