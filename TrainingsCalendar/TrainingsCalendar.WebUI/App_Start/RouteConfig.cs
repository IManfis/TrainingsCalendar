using System.Web.Mvc;
using System.Web.Routing;

namespace TrainingsCalendar.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new
                {
                    controller = "Trainings", 
                    action = "Index", 
                    id = UrlParameter.Optional
                }
            );

            routes.MapRoute(null,
             "{controller}/{action}/{mounth}",
             new
             {
                 controller = "Trainings",
                 action = "Index",
                 mounth = (string)null
             }
             );
        }
    }
}