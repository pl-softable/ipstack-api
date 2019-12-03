namespace ipstack.Geolocation.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using DataAccess;

    public class ValuesController : ApiController
    {
        private readonly ApplicationDbContext dbContext;

        public ValuesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}