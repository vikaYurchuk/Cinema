using Cinema.Helpers;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Cinema.Helpers;
using Newtonsoft.Json.Linq;

namespace Cinema;

public class EmailService : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        MailJetSettings? settings = _configuration.GetSection(nameof(MailJetSettings)).Get<MailJetSettings>();
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        MailjetClient client = new MailjetClient(settings.ApiKey, settings.ApiSecret);
        MailjetRequest request = new MailjetRequest
        {
            Resource = Send.Resource,
        }
            .Property(Send.FromEmail, "vikaschool26yurchyk@gmail.com")
            .Property(Send.FromName, "Group")
            .Property(Send.Subject, subject)
            //.Property(Send.TextPart, )
            .Property(Send.HtmlPart, htmlMessage)
            .Property(Send.Recipients, new JArray {
                new JObject {
                    {"Email", email}
                }
            });

        var res = await client.PostAsync(request);

    }
}