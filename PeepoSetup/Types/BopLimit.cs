
using System.Collections.Generic;

namespace PeepoSetup.Types;

public readonly record struct BopLimit
{
    public float CamberFrontOffset { get; init; }
    public float CamberRearOffset { get; init; }
    
    public List<string> AffectedCars { get; init; }
}
