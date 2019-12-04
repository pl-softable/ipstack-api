namespace ipstack.Geolocation.Services.Models.DTO
{
    public class GeolocationDto
    {
        public string Ip { get; set; }

        public string Type { get; set; }

        public string ContinentCode { get; set; }

        public string ContinentName { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string RegionCode { get; set; }

        public string RegionName { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int GeonameId { get; set; }

        public string Capital { get; set; }

        public string CountryFlag { get; set; }

        public string CountryFlagEmoji { get; set; }

        public string CountryFlagEmojiUnicode { get; set; }

        public string CallingCode { get; set; }

        public bool IsEu { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Native { get; set; }
    }
}