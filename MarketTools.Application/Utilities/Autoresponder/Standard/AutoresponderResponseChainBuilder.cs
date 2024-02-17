using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder;
using MarketTools.Application.Models.Autoresponder.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard
{
    public class AutoresponderResponseChainBuilder<TBody>(AutoresponderContext _context, AutoresponderRequestModel _request, StringBuilder _reportBuilder, TBody _body)
    {
        public AutoresponderResponseChainBuilder<TResponse> Use<TResponse>(AutoresponderResponseHandler<TBody, TResponse> handler)
        {
            handler.Request = _request;
            handler.ReportBuilder = _reportBuilder;
            handler.Context = _context;
            TResponse response = handler.Handle(_body);

            return new AutoresponderResponseChainBuilder<TResponse>(_context, _request, _reportBuilder, response);
        }

        public TBody Get()
        {
            return _body;
        }
    }
}
