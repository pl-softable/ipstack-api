namespace ipstack.Geolocation.DataAccess.Models
{
    using Newtonsoft.Json;

    public class GeolocationResponse
    {
        [JsonProperty(PropertyName = "ip")] public string Ip { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "continent_code")]
        public string ContinentCode { get; set; }

        [JsonProperty(PropertyName = "continent_name")]
        public string ContinentName { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "country_name")]
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "region_code")]
        public string RegionCode { get; set; }

        [JsonProperty(PropertyName = "region_name")]
        public string RegionName { get; set; }

        [JsonProperty(PropertyName = "city")] public string City { get; set; }

        [JsonProperty(PropertyName = "zip")] public string ZipCode { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "location")]
        public Location Location { get; set; }
    }
}