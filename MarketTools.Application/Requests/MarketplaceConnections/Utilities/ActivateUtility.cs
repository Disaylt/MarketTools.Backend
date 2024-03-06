using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.Utilities
{
    internal class ActivateUtility(IConnectionValidatorService _connectionValidatorService)
    {
        public async Task TryActivateAsync(string newValue, MarketplaceConnectionEntity connection)
        {
            if (string.IsNullOrEmpty(newValue))
            {
                connection.IsActive = false;
            }
            else
            {
                await _connectionValidatorService.CheckServices(connection);
                connection.IsActive = true;
            }
            connection.NumConnectionsAttempt = 0;
        }
    }
}
