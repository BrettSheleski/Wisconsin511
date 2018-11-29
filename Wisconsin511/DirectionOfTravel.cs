using Newtonsoft.Json;
using System;

namespace Wisconsin511
{
    public enum DirectionOfTravel
    {
        None,
        [JsonProperty("All Directions")]
        All,
        Northbound,
        Eastbound,
        Southbound,
        Westbound,
        Inbound,
        Outbound,
        [JsonProperty("Both Directions")]
        Both,
        Unknown,
        [JsonProperty("Eastbound/Southbound")]
        EastboundSouthbound
    }
}