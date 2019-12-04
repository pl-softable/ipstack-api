namespace ipstack.Geolocation.DataAccess.Models
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;

    public class Language
    {
        [Key]
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "native")]
        public string Native { get; set; }
    }
}