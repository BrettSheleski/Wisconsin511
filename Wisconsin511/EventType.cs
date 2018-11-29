using Newtonsoft.Json;

namespace Wisconsin511
{
    public enum EventType
    {
        [JsonProperty("accidentsAndIncidents")]
        AccidentsAndIncidents,

        [JsonProperty("roadwork")]
        Roadwork,

        [JsonProperty("specialEvents")]
        SpecialEvents,

        [JsonProperty("closures")]
        Closures,

        [JsonProperty("transitMode")]
        TransitMode,

        [JsonProperty("generalInfo")]
        GeneralInfo,

        [JsonProperty("winterDrivingIndex")]
        WinterDrivingIndex
    }
}