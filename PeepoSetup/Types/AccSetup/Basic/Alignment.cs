using System.Collections.Generic;
using Newtonsoft.Json;

namespace PeepoSetup.Types.AccSetup.Basic;

public readonly record struct Alignment
{
    [JsonProperty("camber")]
    public List<int> Camber { get; init; }

    [JsonProperty("toe")]
    public List<int> Toe { get; init; }

    [JsonProperty("staticCamber")]
    public List<float> StaticCamber { get; init; }

    [JsonProperty("toeOutLinear")]
    public List<float> ToeOutLinear { get; init; }

    [JsonProperty("casterLF")]
    public int CasterLeft { get; init; }

    [JsonProperty("casterRF")]
    public int CasterRight { get; init; }

    [JsonProperty("steerRatio")]
    public int SteerRatio { get; init; }
}
