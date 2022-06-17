using Newtonsoft.Json;
using PeepoSetup.Models.Advanced;
using PeepoSetup.Types.AccSetup.Basic;

namespace PeepoSetup.Types.AccSetup;

public readonly record struct Setup
{
    [JsonProperty("carName")]
    public string CarName { get; init; }

    [JsonProperty("basicSetup")]
    public BasicSetup BasicSetup { get; init; }

    [JsonProperty("advancedSetup")]
    public AdvancedSetup AdvancedSetup { get; init; }

    [JsonProperty("trackBopType")]
    public int TrackBopType { get; init; }
}
