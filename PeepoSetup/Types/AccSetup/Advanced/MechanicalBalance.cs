using Newtonsoft.Json;
using System.Collections.Generic;

namespace PeepoSetup.Models.Advanced;

public readonly record struct MechanicalBalance
{
    [JsonProperty("aRBFront")]
    public int ArbFront { get; init; }

    [JsonProperty("aRBRear")]
    public int ArbRear { get; init; }

    [JsonProperty("wheelRate")]
    public List<int> WheelRate { get; init; }

    [JsonProperty("bumpStopRateUp")]
    public List<int> BumpStopRateUp { get; init; }

    [JsonProperty("bumpStopRateDn")]
    public List<int> BumpStopRateDown { get; init; }

    [JsonProperty("bumpStopWindow")]
    public List<int> BumpStopWindow { get; init; }

    [JsonProperty("brakeTorque")]
    public int BrakeTorque { get; init; }
    
    [JsonProperty("brakeBias")]
    public int BrakeBias { get; init; }
}
