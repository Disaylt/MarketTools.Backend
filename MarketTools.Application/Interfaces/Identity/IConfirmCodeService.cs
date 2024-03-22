using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Identity
{
    public interface IConfirmCodeService
    {
        public Task<string> CreateAsync(string email);
        public Task<bool> CheckAsync(string code, string email);
    }
}
