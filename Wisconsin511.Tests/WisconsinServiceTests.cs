using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Wisconsin511.Tests
{
    [TestClass]
    public class WisconsinServiceTests
    {
        [TestMethod]
        public void ApiKeyIsSetCorrectly()
        {
            // setup
            string apiKey = "some random string";
            WisconsinService service = new WisconsinService(apiKey);

            // act
            string serviceApiKey = service.ApiKey;

            // verify
            Assert.AreEqual(apiKey, serviceApiKey);
        }

        [TestMethod]
        public async Task GetAllEventsGetsEvents()
        {
            // setup
            WisconsinService service = GetService();

            // act
            var events = await service.GetEventsAsync();

            
            // verify
            Assert.IsNotNull(events);
            Assert.IsTrue(events.Length > 0);
        }

        [TestMethod]
        public async Task GetAllRoadways()
        {
            // setup
            WisconsinService service = GetService();

            // act
            var roadways = await service.GetRoadwaysAsync();


            // verify
            Assert.IsNotNull(roadways);
            Assert.IsTrue(roadways.Length > 10);
            Assert.IsFalse(roadways.Any(r => r.Name == null));
        }

        [TestMethod]
        public async Task GetAllCameras()
        {
            // setup
            WisconsinService service = GetService();

            // act
            var cameras = await service.GetCamerasAsync();


            // verify
            Assert.IsNotNull(cameras);
            Assert.IsTrue(cameras.Length > 10);
        }

        [TestMethod]
        public async Task GetMessageSigns()
        {
            // setup
            WisconsinService service = GetService();

            // act
            var messageSigns = await service.GetMessageSignsAsync();


            // verify
            Assert.IsNotNull(messageSigns);
            Assert.IsTrue(messageSigns.Length > 10);
        }

        [TestMethod]
        public async Task GetAlerts()
        {
            // setup
            WisconsinService service = GetService();

            // act
            var alerts = await service.GetAlertsAsync();


            // verify
            Assert.IsNotNull(alerts);
            Assert.IsTrue(alerts.Length > 0);
        }

        [TestMethod]
        public async Task GetWinterRoadConditions()
        {
            // setup
            WisconsinService service = GetService();

            // act
            var winterRoadConditions = await service.GetWinterRoadConditionsAsync();


            // verify
            Assert.IsNotNull(winterRoadConditions);
            Assert.IsTrue(winterRoadConditions.Length > 10);
        }



        private WisconsinService GetService()
        {
            string apiKey = System.IO.File.ReadAllText(@"c:\temp\wi511key.txt");

            return new WisconsinService(apiKey);
        }
    }
}
