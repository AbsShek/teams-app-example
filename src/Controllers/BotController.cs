using Microsoft.Bot.Builder.BotFramework;
using Microsoft.Bot.Builder.Integration.AspNet.WebApi;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TeamsAppMsalRazor.Bots;

namespace TeamsAppMsalRazor.Controllers
{
    public class BotController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Message()
        {
            // DO NOT LEAVE IT LIKE THIS IN PRODUCTION!
            // Register the adapter and bot with an IoC container as singletons.
            var adapter = new BotFrameworkHttpAdapter(
                        new ConfigurationCredentialProvider
                        {
                            AppId = ConfigurationManager.AppSettings["TeamsApp.ClientId"],
                            Password = ConfigurationManager.AppSettings["TeamsApp.Password"]
                        }
                    );
            var bot = new MessageBot();

            // Process the request.
            var response = new HttpResponseMessage();
            await adapter.ProcessAsync(Request, response, bot);
            return response;
        }
    }
}