namespace ipstack.Geolocation.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Geolocations",
                c => new
                    {
                        Ip = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        ContinentCode = c.String(),
                        ContinentName = c.String(),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        RegionCode = c.String(),
                        RegionName = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        GeonameId = c.Int(nullable: false),
                        Capital = c.String(),
                        CountryFlag = c.String(),
                        CountryFlagEmoji = c.String(),
                        CountryFlagEmojiUnicde = c.String(),
                        CallingCode = c.String(),
                        IsEu = c.Boolean(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Native = c.String(),
                    })
                .PrimaryKey(t => t.Ip);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Geolocations");
        }
    }
}
