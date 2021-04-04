using Microsoft.Graph;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TeamsAppMsalRazor.Controllers
{
    using Models;

    public class TabController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var tokenCookie = Request.Cookies["auth_accesstoken"];

            var graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) => {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenCookie.Value);
                return Task.CompletedTask;
            }));

            var user = await graphServiceClient.Me.Request().GetAsync();
            var model = new TabModel
            {
                GraphId = user.Id,
                GraphDisplayName = user.DisplayName,
                GraphUpn = user.UserPrincipalName
            };

            return View(model);
        }
    }
}
