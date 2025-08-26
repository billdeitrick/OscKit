using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscFalse : IOscWriteable, IEquatable<OscFalse>, IComparable<OscFalse>
{
    
    public OscFalse()
    {
        // This class represents a false value in OSC, which is typically used to indicate a boolean false.
        // It does not contain any properties or methods, as it serves as a marker type.
    }

    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        // No-op for False value
    }
    
    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.False;
    }

    public int CompareTo(OscFalse other)
    {
        // False is considered equal to another False
        return 0;
    }

    public bool Equals(OscFalse other)
    {
        // False is considered equal to another False
        return true;
    }

    public static bool operator ==(OscFalse left, OscFalse right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OscFalse left, OscFalse right)
    {
        return !left.Equals(right);
    }
    
}