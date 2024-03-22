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

    public class CommandHandler(IEmailSender _emailSender, IConfirmCodeService _confirmCodeService)
        : IRequestHandler<SendConfirmCodeCommand, Unit>
    {
        public async Task<Unit> Handle(SendConfirmCodeCommand request, CancellationToken cancellationToken)
        {
            string code = await _confirmCodeService.CreateAsync(request.Email);
            string subject = "Код подтверждения.";
            string message = $"Код: {code}.\r\n Действителен в течении 24 часов.";

            await _emailSender.SendAsync(request.Email, subject, message);

            return Unit.Value;
        }
    }
}
