namespace ipstack.Geolocation.WebApi
{
    using AutoMapper;
    using DataAccess.Models;
    using Services.Models.DTO;

    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Geolocation, GeolocationDto>();
        }
    }
}