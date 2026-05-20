using Microsoft.AspNetCore.Identity.UI.Services;

public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Do nothing (for development)
        return Task.CompletedTask;
    }
}