namespace OutputCache_test.FunctionApp.CP.NotificationFunctions.Models;

public sealed class EmailMessage
{
    public string Body { get; set; } = null!;
    public string To { get; set; } = null!;
    public string Subject { get; set; } = null!;
}
