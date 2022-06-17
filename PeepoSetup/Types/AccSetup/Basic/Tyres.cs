using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeepoSetup.Types.AccSetup.Basic;

public readonly record struct Tyres
{
    [JsonProperty("tyreCompound")]
    public int Compound { get; init; }

    [JsonProperty("tyrePressure")]
    public List<int> Pressures { get; init; }
}
