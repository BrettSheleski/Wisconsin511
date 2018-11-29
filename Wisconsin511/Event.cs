using Newtonsoft.Json;

namespace Wisconsin511
{
    public class Event
    {
        public string LastUpdated { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PlannedEndDate { get; set; }
        public string Reported { get; set; }
        public string StartDate { get; set; }
        public string ID { get; set; }
        public string RegionName { get; set; }
        public string CountyName { get; set; }
        public string Severity { get; set; }
        public string RoadwayName { get; set; }
        public string DirectionOfTravel { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string LanesAffected { get; set; }
        public object LanesStatus { get; set; }
        public object LcsEntries { get; set; }
        public string NavteqLinkId { get; set; }
        public object PrimaryLocation { get; set; }
        public object SecondaryLocation { get; set; }
        public object FirstArticleCity { get; set; }
        public object SecondCity { get; set; }

        [JsonProperty("EventType")]
        public EventType Type { get; set; }

        [JsonProperty("EventSubType")]
        public string EventDetails { get; set; }

        public object MapEncodedPolyline { get; set; }
    }
}