namespace ipstack.Geolocation.Services.Services.API
{
    using System.Threading.Tasks;
    using Models.DTO;

    public interface IGeolocationService
    {
        Task AddGeolocation(string ipAddress);
        Task<GeolocationDto> GetGeolocation(string ipAddress);
        Task DeleteGeolocation(string ipAddress);
    }
}