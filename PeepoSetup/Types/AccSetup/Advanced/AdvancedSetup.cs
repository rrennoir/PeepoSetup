using Newtonsoft.Json;

namespace PeepoSetup.Models.Advanced;

public readonly record struct AdvancedSetup
{
    [JsonProperty("mechanicalBalance")]
    public MechanicalBalance MechanicalBalance { get; init; }
    
    [JsonProperty("dampers")]
    public Dampers Dampers { get; init; }
    
    [JsonProperty("aeroBalance")]
    public AreoBalance AreoBalance { get; init; }

    [JsonProperty("drivetrain")]
    public DriveTrain DriveTrain { get; init; }
}
