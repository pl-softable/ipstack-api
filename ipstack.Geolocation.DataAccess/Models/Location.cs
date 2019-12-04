namespace ipstack.Geolocation.DataAccess.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Location
    {
        [Key]
        [JsonProperty(PropertyName = "geoname_id")]
        public int GeonameId { get; set; }

        [JsonProperty(PropertyName = "capital")]
        public string Capital { get; set; }
        
        [NotMapped]
        [JsonProperty(PropertyName = "languages")]
        public ICollection<Language> Languages { get; set; }

        [JsonProperty(PropertyName = "country_flag")]
        public string CountryFlag { get; set; }

        [JsonProperty(PropertyName = "country_flag_emoi")]
        public string CountryFlagEmoji { get; set; }

        [JsonProperty(PropertyName = "country_flag_emoji_unicode")]
        public string CountryFlagEmojiUnicode { get; set; }

        [JsonProperty(PropertyName = "calling_code")]
        public string CallingCode { get; set; }

        [JsonProperty(PropertyName = "is_eu")] 
        public bool IsEu { get; set; }
    }
}