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
        public AutoresponderContext Context { get; set; }
        public AutoresponderRequestModel Request { get; set; }
        public StringBuilder ReportBuilder { get; set; }

        public AutoresponderResponseHandler(AutoresponderContext context, AutoresponderRequestModel request, StringBuilder reportBuilder)
        {
            Context = context;
            Request = request;
            ReportBuilder = reportBuilder;

            ReportBuilder.AppendLine("");
        }

        public abstract TResponse Handle(TBody body);
    }
}
