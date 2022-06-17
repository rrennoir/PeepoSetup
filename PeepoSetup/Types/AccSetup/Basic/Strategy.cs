using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeepoSetup.Types.AccSetup.Basic
{
    public readonly record struct Strategy
    {
        [JsonProperty("fuel")]
        public int Fuel { get; init; }

        [JsonProperty("nPitStops")]
        public int PitStopCount { get; init; }

        [JsonProperty("tyreSet")]
        public int TyreSet { get; init; }

        [JsonProperty("frontBrakePadCompound")]
        public int FrontBrakeCompound { get; init; }

        [JsonProperty("rearBrakePadCompound")]
        public int RearBrakeCompound { get; init; }

        [JsonProperty("pitStrategy")]
        public List<PitStrategy> PitStrategies { get; init; }

        [JsonProperty("fuelPerLap")]
        public float FuelPerLaps { get; init; }
    }
}
