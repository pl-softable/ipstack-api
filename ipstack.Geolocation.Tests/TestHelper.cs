namespace ipstack.Geolocation.Tests
{
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Services.Services;
    using Services.Services.API;
    using WebApi;

    public static class TestHelper
    {
        public static IGeolocationService GetGeolocationService()
        {
            var mapper =
                new MapperConfiguration(options => { options.AddProfile(new MappingsProfile()); }).CreateMapper();

            var geolocationService = new GeolocationService(BuildDbContext(), mapper);

            return geolocationService;
        }

        private static ApplicationDbContext BuildDbContext()
        {
            var builder = new ApplicationDbContext();

            builder.Database.Delete();

            var geolocation = new Geolocation
            {
                Ip = "127.0.0.1",
                IsEu = true
            };

            builder.Geolocations.Add(geolocation);
            builder.SaveChanges();

            return builder;
        }
    }
}