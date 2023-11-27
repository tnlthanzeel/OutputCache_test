using OutputCache_test.Core.Common.Dtos;
using OutputCache_test.Core.Common.Interfaces;

namespace OutputCache_test.Infrastructure.NotificationServices;

public sealed class EmailService : IEmailService
{
    public Task<string> GetEmailTemplate(string emailTemplateName)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailByQueue(EmailModel email)
    {
        throw new NotImplementedException();
    }
}
