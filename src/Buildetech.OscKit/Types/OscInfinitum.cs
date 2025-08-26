using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscInfinitum : IOscWriteable, IEquatable<OscInfinitum>, IComparable<OscInfinitum>
{
    
    public OscInfinitum()
    {
        // This class represents an infinitum value in OSC, which is typically used to indicate an infinite value.
        // It does not contain any properties or methods, as it serves as a marker type.
    }
    
    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        // No-op for Infinitum value
    }
    
    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.Int32;
    }
    
    public int CompareTo(OscInfinitum other)
    {
        // Infinitum is considered equal to another Infinitum
        return 0;
    }
    
    public bool Equals(OscInfinitum other)
    {
        // Infinitum is considered equal to another Infinitum
        return true;
    }
    
    public static bool operator ==(OscInfinitum left, OscInfinitum right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscInfinitum left, OscInfinitum right)
    {
        return !left.Equals(right);
    }
    
    
}