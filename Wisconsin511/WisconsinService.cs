using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Wisconsin511
{
    public class WisconsinService : IWisconsinService
    {
        public WisconsinService(string apiKey)
        {
            ApiKey = apiKey;
        }

        public string ApiKey { get;  }

        public Task<Alert[]> GetAlertsAsync()
        {
            return GetAlertsAsync(CancellationToken.None);
        }

        public Task<Alert[]> GetAlertsAsync(CancellationToken cancellationToken)
        {
            return DeserializeJsonFromUrl<Alert[]>($"https://511wi.gov/api/getalerts?key={ApiKey}&format=json");
        }

        public Task<Camera[]> GetCamerasAsync()
        {
            return GetCamerasAsync(CancellationToken.None);
        }

        public Task<Camera[]> GetCamerasAsync(CancellationToken cancellationToken)
        {
            return DeserializeJsonFromUrl<Camera[]>($"https://511wi.gov/api/getcameras?key={ApiKey}&format=json");
        }

        public Task<Event[]> GetEventsAsync()
        {
            return GetEventsAsync(CancellationToken.None);
        }

        public Task<Event[]> GetEventsAsync(CancellationToken cancellationToken)
        {
            return DeserializeJsonFromUrl<Event[]>($"https://511wi.gov/api/getevents?key={ApiKey}&format=json");
        }

        public Task<MessageSign[]> GetMessageSignsAsync()
        {
            return GetMessageSignsAsync(CancellationToken.None);
        }

        public Task<MessageSign[]> GetMessageSignsAsync(CancellationToken cancellationToken)
        {
            return DeserializeJsonFromUrl<MessageSign[]>($"http://511wi.gov/api/getmessagesigns?key={ApiKey}&format=json");
        }

        public Task<Roadway[]> GetRoadwaysAsync()
        {
            return GetRoadwaysAsync(CancellationToken.None);
        }

        public Task<Roadway[]> GetRoadwaysAsync(CancellationToken cancellationToken)
        {
            return DeserializeJsonFromUrl<Roadway[]>($"http://511wi.gov/api/getroadways?key={ApiKey}&format=json");
        }

        public Task<WinterRoadCondition[]> GetWinterRoadConditionsAsync()
        {
            return GetWinterRoadConditionsAsync(CancellationToken.None);
        }

        public Task<WinterRoadCondition[]> GetWinterRoadConditionsAsync(CancellationToken cancellationToken)
        {
            return DeserializeJsonFromUrl<WinterRoadCondition[]>($"http://511wi.gov/api/getwinterroadconditions?key={ApiKey}&format=json");
        }

        private static async Task<T> DeserializeJsonFromUrl<T>(string url)
        {
            string json;

            using (WebClient webClient = new WebClient())
            {
                json = await webClient.DownloadStringTaskAsync(url);
            }

            T obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            return obj;
        }
    }
}
