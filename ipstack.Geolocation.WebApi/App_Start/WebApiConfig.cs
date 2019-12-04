namespace ipstack.Geolocation.WebApi
{
    using System.Reflection;
    using System.Web.Http;
    using App_Start;
    using Autofac;
    using Autofac.Integration.WebApi;
    using AutoMapper;
    using ipstack.Geolocation.DataAccess;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using Services.Services;
    using Services.Services.API;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            var mapper = new MapperConfiguration(options =>
            {
                    options.AddProfile(new MappingsProfile());
            }).CreateMapper();

            builder.RegisterInstance(mapper);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<ApplicationDbContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GeolocationService>().As<IGeolocationService>();

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
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}