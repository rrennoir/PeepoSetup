namespace PeepoSetup.Models;

public record RealValueSetup
{
    public string CarName { get; init; }
    public string Track { get; init; }
    public string Bop { get; init; }
    public WheelsFloat TyrePressures { get; init; }
    public string TyreCompound { get; init; }
    public WheelsFloat Camber { get; init; }
    public WheelsFloat Toe { get; init; }
    public WheelsInt WheelRate { get; init; }
    public WheelsInt BumpStopRate { get; init; }
    public WheelsInt BumpStopWindow { get; init; }
    public WheelsInt BumpSlow { get; init; }
    public WheelsInt BumpFast { get; init; }
    public WheelsInt ReboundSlow { get; init; }
    public WheelsInt ReboundFast { get; init; }
    public float CasterLeft { get; init; }
    public float CasterRight { get; init; }
    public int ArbFront { get; init; }
    public int ArbRear { get; init; }
    public int SteerRatio { get; init; }
    public float BrakeBias { get; init; }
    public int BrakeTorque { get; init; }
    public int Preload { get; init; }
    public int Tc1 { get; init; }
    public int Tc2 { get; init; }
    public int Abs { get; init; }
    public int Ecu { get; init; }
    public int BrakeDuctFront { get; init; }
    public int BrakeDuctRear { get; init; }
    public int RideHeightFront { get; init; }
    public int RideHeightRear { get; init; }
    public int Splitter { get; init; }
    public int RearWing { get; init; }
}
