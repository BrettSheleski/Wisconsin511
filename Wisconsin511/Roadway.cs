using Newtonsoft.Json;

namespace Wisconsin511
{
    public class Roadway
    {
        [JsonProperty("RoadwayName")]
        public string Name { get; set; }
        public int? SortOrder { get; set; }
    }
}