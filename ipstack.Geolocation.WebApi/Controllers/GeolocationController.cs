namespace ipstack.Geolocation.WebApi.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;
    using Services.Services.API;

    [RoutePrefix("api/geolocation")]
    public class GeolocationController : ApiController
    {
        private readonly IGeolocationService geolocationService;

        public GeolocationController(IGeolocationService geolocationService)
        {
            this.geolocationService = geolocationService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddNewGeolocationByIpAddres([FromBody] string ipAddress)
        {
            await this.geolocationService.AddGeolocation(ipAddress);

            return await this.GetGeolocationByIpAddress(ipAddress);
        }

        [HttpGet]
        [Route("{ipAddress}")]
        public async Task<IHttpActionResult> GetGeolocationByIpAddress(string ipAddress)
        {
            var result = await this.geolocationService.GetGeolocation(ipAddress);

            return this.Ok(result);
        }

        [HttpDelete]
        [Route("{ipAddress}")]
        public async Task<IHttpActionResult> DeleteGeolocationByIpAddress(string ipAddress)
        {
            await this.geolocationService.DeleteGeolocation(ipAddress);

            return this.Ok();
        }
    }
}