using Newtonsoft.Json;

namespace PeepoSetup.Types.AccSetup.Basic;

public readonly record struct Electronics
{
    [JsonProperty("tC1")]
    public int Tc1 { get; init; }

    [JsonProperty("tC2")]
    public int Tc2 { get; init; }

    [JsonProperty("abs")]
    public int Abs { get; init; }

    [JsonProperty("eCUMap")]
    public int EcuMap { get; init; }

    [JsonProperty("fuelMix")]
    public int FuelMix { get; init; }

    [JsonProperty("telemetryLap")]
    public int Telemetrylaps { get; init; }
}
