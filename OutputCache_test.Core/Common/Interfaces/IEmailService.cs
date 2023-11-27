using OutputCache_test.Core.Common.Dtos;

namespace OutputCache_test.Core.Common.Interfaces;

public interface IEmailService
{
    Task SendEmailByQueue(EmailModel email);

    Task<string> GetEmailTemplate(string emailTemplateName);
}
