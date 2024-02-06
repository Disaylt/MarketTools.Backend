using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Models.Autoresponder.Standard;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.Autoresponder.Standard
{
    internal class AutoresponderResponseServiceFactory
        (IAutoresponderContextWriter _autoresponderContextWriter, IServiceProvider _serviceProvider)
        : IAutoresponderResponseServiceFactory
    {
        public IAutoresponderResponseService Create(AutoresponderContext context)
        {
            _autoresponderContextWriter.Write(context);

            return _serviceProvider.GetRequiredService<IAutoresponderResponseService>();
        }
    }
}
