using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Mail
{
    public interface IEmailService
    {
        public Task SendAsync(string email, string subject, string message);
    }
}
