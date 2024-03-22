using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Common
{
    internal class ContextService<T> : IContextService<T>
    {
        private T? _context;
        public T Context
        {
            get
            {
                if (_context == null)
                {
                    throw new AppNotFoundException($"Контекст данных '{typeof(T).Name}' не установлен.");
                }
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public bool IsExists()
        {
            return _context != null;
        }
    }
}
