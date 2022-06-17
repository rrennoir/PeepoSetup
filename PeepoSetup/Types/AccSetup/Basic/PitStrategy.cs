using Newtonsoft.Json;

namespace PeepoSetup.Types.AccSetup.Basic;

public readonly record struct PitStrategy
{
    [JsonProperty("fuelToAdd")]
    public int FuelToAdd { get; init; }

    [JsonProperty("tyres")]
    public Tyres Tyres { get; init; }

    [JsonProperty("tyreSet")]
    public int TyreSet { get; init; }

    [JsonProperty("frontBrakePadCompound")]
    public int FrontBrakePadCompound { get; init; }

    [JsonProperty("rearBrakePadCompound")]
    public int RearBrakePadCompound { get; init; }
}
