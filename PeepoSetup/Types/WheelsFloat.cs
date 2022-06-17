using System.Collections.Generic;

namespace PeepoSetup.Models;

public readonly record struct WheelsFloat
{
    public float FrontLeft { get; init; }
    public float FrontRight { get; init; }
    public float RearLeft { get; init; }
    public float RearRight { get; init; }
    
    public WheelsFloat(IList<int> values, float baseValue, float step)
    {
        FrontLeft = baseValue + values[0] * step;
        FrontRight = baseValue + values[1] * step;
        RearLeft = baseValue + values[2] * step;
        RearRight = baseValue + values[3] * step;
    }
}
