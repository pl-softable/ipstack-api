namespace ipstack.Geolocation.Services.Services
{
    using System;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Linq;
    using System.Threading.Tasks;
    using API;
    using AutoMapper;
    using DataAccess;
    using DataAccess.Models;
    using Models.DTO;

    public class GeolocationService : IGeolocationService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GeolocationService(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task AddGeolocation(string ipAddress)
        {
            var apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            var apiToken = ConfigurationManager.AppSettings["ApiToken"];

            if (await this.dbContext.Geolocations.AnyAsync(item => item.Ip == ipAddress))
            {
                throw new Exception("IP exists in the database.");
            }

            var result = await HttpHelper.GetApiResponse<GeolocationResponse>(apiToken, apiUrl, ipAddress);

            this.dbContext.Geolocations.Add(this.ConvertToDatabaseObject(result));

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteGeolocation(string ipAddress)
        {
            var result = await this.dbContext.Geolocations
                .FirstOrDefaultAsync(item => item.Ip == ipAddress);

            if (result == null) throw new Exception("There is no geolocation associated with this IP.");

            this.dbContext.Geolocations.Remove(result);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<GeolocationDto> GetGeolocation(string ipAddress)
        {
            var result = await this.dbContext.Geolocations
                .FirstOrDefaultAsync(item => item.Ip == ipAddress);

            if (result == null) throw new Exception("There is no geolocation associated with this IP.");

            return this.mapper.Map<GeolocationDto>(result);
        }

        private Geolocation ConvertToDatabaseObject(GeolocationResponse response)
        {
            var geolocation = new Geolocation();

            this.ConvertGeolocation(response, ref geolocation);
            this.ConvertLocation(response.Location, ref geolocation);
            this.ConvertLanguage(response.Location.Languages.FirstOrDefault(), ref geolocation);

            return geolocation;
        }

        private void ConvertLanguage(Language language, ref Geolocation geolocation)
        {
            geolocation.Code = language.Code;
            geolocation.Name = language.Name;
            geolocation.Native = language.Native;
        }

        private void ConvertLocation(Location location, ref Geolocation geolocation)
        {
            geolocation.GeonameId = location.GeonameId;
            geolocation.Capital = location.Capital;
            geolocation.CountryFlag = location.CountryFlag;
            geolocation.CountryFlagEmoji = location.CountryFlagEmoji;
            geolocation.CountryFlagEmojiUnicde = location.CountryFlagEmojiUnicode;
            geolocation.CallingCode = location.CallingCode;
            geolocation.IsEu = location.IsEu;
        }

        private void ConvertGeolocation(GeolocationResponse response, ref Geolocation geolocation)
        {
            geolocation.Ip = response.Ip;
            geolocation.Type = response.Type;
            geolocation.ContinentCode = response.ContinentCode;
            geolocation.ContinentName = response.ContinentName;
            geolocation.CountryCode = response.CountryCode;
            geolocation.CountryName = response.CountryName;
            geolocation.RegionCode = response.RegionCode;
            geolocation.RegionName = response.RegionName;
            geolocation.City = response.City;
            geolocation.ZipCode = response.ZipCode;
            geolocation.Latitude = response.Latitude;
            geolocation.Longitude = response.Longitude;
        }
    }
}