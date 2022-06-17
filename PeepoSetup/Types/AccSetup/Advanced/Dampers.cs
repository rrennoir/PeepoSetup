using Newtonsoft.Json;
using System.Collections.Generic;

namespace PeepoSetup.Models.Advanced;

public readonly record struct Dampers
{
    [JsonProperty("bumpSlow")]
    public List<int> BumpSlow { get; init; }

    [JsonProperty("bumpFast")]
    public List<int> BumpFast { get; init; }

    [JsonProperty("reboundSlow")]
    public List<int> ReboundSlow { get; init; }

    [JsonProperty("reboundFast")]
    public List<int> ReboundFast { get; init; }
} 
