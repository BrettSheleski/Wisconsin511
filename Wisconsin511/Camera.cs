using Newtonsoft.Json;
using System;

namespace Wisconsin511
{
    public class Camera
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonProperty("ID")]
        public string Id { get; set; }
        public string Name { get; set; }
        public DirectionOfTravel DirectionOfTravel { get; set; }
        public string RoadwayName { get; set; }
        public Uri Url { get; set; }
        public bool Disabled { get; set; }
        public bool Blocked { get; set; }
    }
}