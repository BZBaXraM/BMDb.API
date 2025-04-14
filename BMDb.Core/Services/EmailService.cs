using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;

namespace BMDb.Core.Services;

public class EmailService : IEmailService
{
    private readonly EmailConfig _config;

    public EmailService(IOptions<EmailConfig> options)
    {
        _config = options.Value;
    }

    public async Task SendAccessCodeAsync(string email, string code)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(_config.From, _config.From));
        message.To.Add(new MailboxAddress(email, email));
        message.Subject = "Access Code";
        message.Body = new TextPart("html")
        {
            Text = $"<h1>Access Code</h1><p>Your access code is: <strong>{code}</strong></p>"
        };

        using var client = new SmtpClient();

        client.ServerCertificateValidationCallback = (s, c, h, e) => true;

        await client.ConnectAsync(_config.SmtpServer, _config.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_config.UserName, _config.Password);
        await client.SendAsync(message);

        await client.DisconnectAsync(true);
    }
}