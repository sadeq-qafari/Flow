using System.Collections.Generic;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Providers.Email
{
    public class EmailClient
    {
        private readonly IOptions<EmailOptions> _options;

        public EmailClient(IOptions<EmailOptions> options)
        {
            _options = options;
        }

        public Task SendAsPlain(MailboxAddress from, IEnumerable<MailboxAddress> to, string subject, string body) =>
            Send(from, to, subject, "plain", body);
        
        public Task SendAsHtml(MailboxAddress from, IEnumerable<MailboxAddress> to, string subject, string body) =>
            Send(from, to, subject, "html", body);
        
        public async Task Send(MailboxAddress from, IEnumerable<MailboxAddress> to, string subject, string bodySubType,
            string bodyText)
        {
            var message = new MimeMessage();
            message.From.Add(from);
            foreach (var receiver in to)
            {
                message.To.Add(receiver);
            }

            message.Subject = subject;
            
            message.Body = new TextPart(bodySubType)
            {
                Text = bodyText
            };

            using var client = new SmtpClient();
            await client.ConnectAsync(_options.Value.Host, _options.Value.Port, _options.Value.SecureSocketOptions);

            await client.AuthenticateAsync(_options.Value.Username, _options.Value.Password);

            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}