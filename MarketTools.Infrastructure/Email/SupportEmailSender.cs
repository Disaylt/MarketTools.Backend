using MailKit.Net.Smtp;
using MarketTools.Application.Interfaces.Mail;
using MarketTools.Domain.Common.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Email
{
    internal class SupportEmailSender(IOptions<SequreSettings> _options) : IEmailSender
    {
        private readonly string _email = _options.Value.SupportEmail.Email;
        private readonly string _password = _options.Value.SupportEmail.Password;

        public async Task SendAsync(string email, string subject, string message)
        {
            using MimeMessage emailMessage = CreateMessage(email, subject, message);

            await SendAsync(emailMessage);
        }

        private async Task SendAsync(MimeMessage mimeMessage)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                await smtpClient.ConnectAsync("smtp.timeweb.ru", 465, true);
                await smtpClient.AuthenticateAsync(_email, _password);
                await smtpClient.SendAsync(mimeMessage);

                await smtpClient.DisconnectAsync(true);
            }
        }

        private MimeMessage CreateMessage(string email, string subject, string message)
        {
            MimeMessage emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("MP-SNAKE", _email));
            emailMessage.To.Add(new MailboxAddress("User", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = message
            };

            return emailMessage;
        }
    }
}
