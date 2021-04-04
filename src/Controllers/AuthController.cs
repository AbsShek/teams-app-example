using System.Web.Mvc;

namespace TeamsAppMsalRazor.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Popup()
        {
            return View();
        }
    }
}
