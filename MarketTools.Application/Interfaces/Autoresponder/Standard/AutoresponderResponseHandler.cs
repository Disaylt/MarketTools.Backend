using MarketTools.Application.Common.Exceptions;
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
        private StringBuilder? _reportBuilder;

        public AutoresponderContext Context { get; set; } = null!;
        public AutoresponderRequestModel Request { get; set; } = null!;
        public StringBuilder ReportBuilder
        {
            get
            {
                if(_reportBuilder == null)
                {
                    throw new AppNotFoundException("Сборщик отчетов не присвоен");
                }

                return _reportBuilder;
            }
            set
            {
                value.AppendLine("");
                _reportBuilder = value;
            }
        }

        public abstract TResponse Handle(TBody body);
    }
}
