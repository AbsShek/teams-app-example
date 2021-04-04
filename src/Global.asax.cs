using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TeamsAppMsalRazor
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(RegisterHttpRoutes);
            RegisterMvcRoutes(RouteTable.Routes);
        }

        public void RegisterHttpRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "TeamsBot",
                routeTemplate: "bot/{action}",
                defaults: new { controller = "bot" },
                constraints: null
            );
        }

        private void RegisterMvcRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "TeamsApp",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
