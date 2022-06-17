using Newtonsoft.Json;

namespace PeepoSetup.Types.AccSetup.Basic;

public readonly record struct BasicSetup
{
    [JsonProperty("tyres")]
    public Tyres Tyres { get; init; }
    
    [JsonProperty("alignment")]
    public Alignment Alignment { get; init; }

    [JsonProperty("electronics")]
    public Electronics Electronics { get; init; }

    [JsonProperty("strategy")]
    public Strategy Strategy { get; init; }
}
