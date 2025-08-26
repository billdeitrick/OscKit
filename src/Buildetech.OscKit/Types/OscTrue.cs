using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscTrue : IOscWriteable, IEquatable<OscTrue>, IComparable<OscTrue>
{
    
    public OscTrue()
    {
        // This class represents a true value in OSC, which is typically used to indicate a boolean true.
        // It does not contain any properties or methods, as it serves as a marker type.
    }

    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        // No-op for True value
    }
    
    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.True;
    }

    public int CompareTo(OscTrue other)
    {
        // True is considered equal to another True
        return 0;
    }

    public bool Equals(OscTrue other)
    {
        // True is considered equal to another True
        return true;
    }

    public static bool operator ==(OscTrue left, OscTrue right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OscTrue left, OscTrue right)
    {
        return !left.Equals(right);
    }
    
}