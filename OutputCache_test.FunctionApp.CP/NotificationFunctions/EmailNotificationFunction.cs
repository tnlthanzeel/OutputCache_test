using OutputCache_test.FunctionApp.CP.NotificationFunctions.Models;
using OutputCache_test.SharedKernal;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Azure.Functions.Worker;
using MimeKit;
using MimeKit.Text;


namespace OutputCache_test.FunctionApp.CP.NotificationFunctions;

public sealed class EmailNotificationFunction
{
    [Function(nameof(SendEmailFunc))]
    public static async Task SendEmailFunc([QueueTrigger(AppConstants.QueueStorage.QueueName.EmailQueue)] EmailMessage emailMessage)
    {
        string smtpEmailAddress = Environment.GetEnvironmentVariable("SMTPEmailAddress")!;
        string smtpEmailHost = Environment.GetEnvironmentVariable("SMTPEmailHost")!;
        string smtpEmailUserName = Environment.GetEnvironmentVariable("SMTPEmailUserName")!;
        string smtpEmailPassword = Environment.GetEnvironmentVariable("SMTPEmailPassword")!;

        MimeMessage message = new();

        message.From.Add(MailboxAddress.Parse(smtpEmailAddress));

        message.To.Add(MailboxAddress.Parse(emailMessage.To));

        message.Subject = emailMessage.Subject;

        message.Body = new TextPart(TextFormat.Html)
        {
            Text = emailMessage.Body
        };
        using var client = new SmtpClient();

        await client.ConnectAsync(smtpEmailHost, 587, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(smtpEmailUserName, smtpEmailPassword);

        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
