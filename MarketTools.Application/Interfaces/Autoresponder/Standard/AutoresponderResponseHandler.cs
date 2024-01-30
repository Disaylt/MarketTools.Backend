using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Autoresponder.Standard
{
    public abstract class AutoresponderResponseHandler<TBody, TResponse>
    {
        protected AutoresponderContext Context { get; }
        protected AutoresponderRequestModel Request { get; }
        protected StringBuilder ReportBuilder { get; }

        public AutoresponderResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder)
        {
            Context = context;
            Request = request;
            ReportBuilder = reportBuilder;
        }

        public abstract TResponse Handle(TBody body);
    }
}
