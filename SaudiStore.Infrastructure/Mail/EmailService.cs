using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using SaudiStore.Application.Contracts.Infrastructure;
using SaudiStore.Application.Models.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSetteings { get; }

        public EmailService(IOptions<EmailSettings> mailSetteings)
        {
            this._emailSetteings = mailSetteings.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSetteings.ApiKey);

            var subject = email.subject;
            var body = email.body;
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSetteings.FromAddress,
                Name = _emailSetteings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from,to,subject,body,body);

            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
                response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
