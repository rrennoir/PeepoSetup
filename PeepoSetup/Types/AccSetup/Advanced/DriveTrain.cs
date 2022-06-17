using Newtonsoft.Json;

namespace PeepoSetup.Models.Advanced;

public readonly record struct DriveTrain
{

    [JsonProperty("preload")]
    public int Preload { get; init; }
}
