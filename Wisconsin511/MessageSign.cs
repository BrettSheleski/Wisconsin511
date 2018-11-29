using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wisconsin511
{
    public class MessageSign
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonProperty("ID")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Roadway { get; set; }

        
        public string DirectionOfTravel { get; set; }
        public List<string> Messages { get; set; }
    }
}