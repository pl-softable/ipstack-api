namespace ipstack.Geolocation.WebApi
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{ipAddress}",
                new {controller = "Geolocation", action = "GetGeolocationByIpAddress", ipAddress = UrlParameter.Optional}
            );
        }
    }
}