﻿using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    public class ConnectionTypeFactory : IConnectionTypeFactory
    {
        private static readonly Dictionary<MarketplaceConnectionType, string> _discriminators = new Dictionary<MarketplaceConnectionType, string>
        {
            {MarketplaceConnectionType.OpenApi, nameof(MarketplaceConnectionOpenApiEntity)}
        };

        public string Get(MarketplaceConnectionType connectionType)
        {
            if(_discriminators.TryGetValue(connectionType, out string? value) && !string.IsNullOrEmpty(value))
            {
                return value;
            }

            throw new AppNotFoundException("Такого вида подключения не существует.");
        }
    }
}
