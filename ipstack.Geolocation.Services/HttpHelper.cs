namespace ipstack.Geolocation.Services
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class HttpHelper
    {
        private static readonly HttpClient httpClient;

        static HttpHelper()
        {
            httpClient = new HttpClient();
        }

        public static async Task<T> GetApiResponse<T>(string accessKey, string apiUrl, string ipAddress)
        {
            var response = await httpClient.GetAsync(JoinUrlParts(accessKey, apiUrl, ipAddress));

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<T>();

            return result;
        }

        private static string JoinUrlParts(string accessKey, string apiUrl, string ipAddress)
        {
            var url = string.Concat(apiUrl, ipAddress, "&access_key=", accessKey, "&format=1");

            return url;
        }
    }
}