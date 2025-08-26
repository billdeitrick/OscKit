using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscLong : IOscWriteable, IEquatable<OscLong>, IComparable<OscLong>
{
    
    public long Value { get; set; }

    /// <summary>
    /// Initialize a new instance of the class with zero value.
    /// </summary>
    public OscLong()
    {
        Value = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OscLong"/> class with the specified long value.
    /// </summary>
    /// <param name="value">The long value to be wrapped.</param>
    public OscLong(long value)
    {
        Value = value;
    }

    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        writer.Write(Value);
    }
    
    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.Int64;
    }
    
    public int CompareTo(OscLong other)
    {
        return Value.CompareTo(other.Value);
    }
    
    public bool Equals(OscLong other)
    {
        return other.Value == Value;
    }
    
    public static bool operator ==(OscLong left, OscLong right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscLong left, OscLong right)
    {
        return !left.Equals(right);
    }
    
}