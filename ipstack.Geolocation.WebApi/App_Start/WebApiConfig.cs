namespace ipstack.Geolocation.WebApi
{
    using System.Web.Http;
    using App_Start;
    using Autofac;
    using ipstack.Geolocation.DataAccess;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationDbContext>()
                .WithParameter("connectionString", "OktaConnectionString")
                .InstancePerLifetimeScope();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );

            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            SwaggerConfig.Register(config);

            var container = builder.Build();
        }
    }
}