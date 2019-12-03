namespace ipstack.Geolocation.WebApi.App_Start
{
    using System.Web.Http;
    using Swashbuckle.Application;

    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "Sofomo (Sofomo)"))
                .EnableSwaggerUi();

        }
    }
}