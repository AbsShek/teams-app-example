using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace TeamsAppMsalRazor.Bots
{
    public class MessageBot : TeamsActivityHandler
    {
        protected override async Task<MessagingExtensionActionResponse> OnTeamsMessagingExtensionFetchTaskAsync(ITurnContext<IInvokeActivity> turnContext, MessagingExtensionAction action, CancellationToken cancellationToken)
        {
            var response = new MessagingExtensionActionResponse()
            {
                Task = new TaskModuleContinueResponse()
                {
                    Value = new TaskModuleTaskInfo()
                    {
                        Height = 200,
                        Width = 400,
                        Title = "Message extension example",
                        Url = new Uri(
                                    new Uri(ConfigurationManager.AppSettings["WebApp.Url"]),
                                    "/auth?redirect=/message")
                                .AbsoluteUri
                    },
                },
            };
            return response;
        }
    }
}