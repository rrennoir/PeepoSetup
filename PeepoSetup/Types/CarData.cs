
using System.Collections.Generic;

namespace PeepoSetup.Types;

public record CarData
{
    public string CarName { get; init; }

    public float ToeFrontOffset { get; init; }
    public float ToeRearOffset { get; init; }
    public float ToeStep { get; init; }

    public float CamberFrontOffset { get; init; }
    public float CamberRearOffset { get; init; }

    public float BrakeBiasOffset { get; init; }
    public float BrakeBiasStep { get; init; }
    public int BrakeTorqueOffset { get; init; }
    
    public IList<int> WheelRatesFront { get; init; }
    public IList<int> WheelRatesRear { get; init; }
    
    public int BumpStopRateOffset { get; init; }
    public int BumpStopRateStep { get; init; }

    public float CasterOffset { get; init; }
    public float CasterStep { get; init; }
    
    public int SteerRatioOffset { get; init; }

    public int EcuOffset { get; init; }

    public int PreloadOffset { get; init; }
    public int PreloadStep { get; init; }

    public int RideHeightFrontOffset { get; init; }
    public int RideHeightRearOffset { get; init; }
    
    public int RearWingOffset { get; init; }
    public int SplitterOffset { get; init; }
    public float PressureOffset { get; init; } = 20.3f;

    public int BumpOffset { get; init; }
    public int FastBumpOffset { get; init; }
    public int ReboundOffset { get; init; }
    public int FastReboundOffset { get; init; }
}
