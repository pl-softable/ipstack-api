namespace ipstack.Geolocation.DataAccess
{
    using System.Data.Entity;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
        }
    }
}