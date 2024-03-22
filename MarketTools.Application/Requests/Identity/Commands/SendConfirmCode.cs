using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Interfaces.Mail;
using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Identity.Commands
{
    public class SendConfirmCodeCommand : IRequest<Unit> 
    {
        public required string Email { get; set; }
    }

    public class CommandHandler(IEmailSender _emailSender, IConfirmCodeService _confirmCodeService, IAuthUnitOfWork _authUnitOfWork)
        : IRequestHandler<SendConfirmCodeCommand, Unit>
    {
        private readonly IRepository<AppIdentityUser> _reporitory = _authUnitOfWork.GetRepository<AppIdentityUser>();

        public async Task<Unit> Handle(SendConfirmCodeCommand request, CancellationToken cancellationToken)
        {
            string code = await _confirmCodeService.CreateAsync();
            string email = await GetEmailAsync();
            string subject = "Код подтверждения.";
            string message = $"Код: {code}.\r\n Действителен в течении 24 часов.";

            await _emailSender.SendAsync(email, subject, message);

            return Unit.Value;
        }

        private async Task<string> GetEmailAsync()
        {
            AppIdentityUser user = await _reporitory.FirstAsync();

            return user.Email ?? throw new AppBadRequestException("Не удалось получить Email пользователя.");
        }
    }
}
