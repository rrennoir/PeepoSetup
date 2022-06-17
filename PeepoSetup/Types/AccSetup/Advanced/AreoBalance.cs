
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PeepoSetup.Models.Advanced
{
    public readonly record struct AreoBalance
    {
        [JsonProperty("rideHeight")]
        public List<int> RideHeight { get; init; }

        [JsonProperty("rodLength")]
        public List<float> RodLength { get; init; }

        [JsonProperty("splitter")]
        public int Splitter { get; init; }

        [JsonProperty("rearWing")]
        public int RearWing { get; init; }

        [JsonProperty("brakeDuct")]
        public List<int> BrakeDuct { get; init; }
    }
}
