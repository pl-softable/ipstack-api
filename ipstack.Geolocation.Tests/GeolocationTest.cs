namespace ipstack.Geolocation.Tests
{
    using System;
    using System.Configuration;
    using System.Threading.Tasks;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class GeolocationTest
    {
        [SetUp]
        public void Setup()
        {
            ConfigurationManager.AppSettings["ApiUrl"] = "http://api.ipstack.com/";
            ConfigurationManager.AppSettings["ApiToken"] = "e71efcab54567e4deadbbe0f08c26ce3";
        }

        [Test]
        public async Task ShouldGetSingleGeolocationResponse()
        {
            var geolocationService = TestHelper.GetGeolocationService();

            var response = await geolocationService.GetGeolocation("127.0.0.1");

            Assert.NotNull(response);
        }

        [Test]
        public async Task ShouldThrowExceptionIfIpAddressDoesNotExists()
        {
            var geolocationService = TestHelper.GetGeolocationService();

            var action = new Func<Task>(async () =>
            {
                await geolocationService.GetGeolocation(("1.1.1.1"));
            });

            await action.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task ShouldAddIpAddressToDatabase()
        {
            var geolocationService = TestHelper.GetGeolocationService();

            await geolocationService.AddGeolocation("217.197.79.53");

            var action = new Func<Task>(async () =>
            {
                await geolocationService.GetGeolocation("217.197.79.53");
            });

            action.Should().NotThrow();
        }

        [Test]
        public async Task ShouldThrowExceptionIfIpAddressIsDuplicated()
        {
            var geolocationService = TestHelper.GetGeolocationService();

            var action = new Func<Task>(async () =>
            {
                await geolocationService.AddGeolocation("127.0.0.1");
            });

            await action.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task ShoulDeleteIpAddressFromDatabase()
        {
            var geolocationService = TestHelper.GetGeolocationService();

            await geolocationService.DeleteGeolocation("127.0.0.1");

            var action = new Func<Task>(async () =>
            {
                await geolocationService.GetGeolocation("127.0.0.1");
            });

            await action.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task ShouldThrowExceptionIfDeleteAddressIpDoesNotExists()
        {
            var geolocationService = TestHelper.GetGeolocationService();

            var action = new Func<Task>(async () =>
            {
                await geolocationService.DeleteGeolocation("217.197.79.53");
            });

            await action.Should().ThrowAsync<Exception>();
        }
    }
}