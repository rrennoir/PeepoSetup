using System.Collections.Generic;

namespace PeepoSetup.Models;

public readonly record struct WheelsInt
{
    public int FrontLeft { get; init; }
    public int FrontRight { get; init; }
    public int RearLeft { get; init; }
    public int RearRight { get; init; }
    
    public WheelsInt(IList<int> values)
    {
        FrontLeft = values[0];
        FrontRight = values[1];
        RearLeft = values[2];
        RearRight = values[3];
    }
}
