namespace ipstack.Geolocation.DataAccess
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("GeolocationConnectionString")
        {
        }

        public DbSet<Geolocation> Geolocations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}