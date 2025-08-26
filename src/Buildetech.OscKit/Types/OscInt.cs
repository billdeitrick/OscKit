using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscInt : IOscWriteable, IEquatable<OscInt>, IComparable<OscInt>
{
    
    public int Value { get; set; }

    /// <summary>
    /// Initialize a new instance of the class with zero value.
    /// </summary>
    public OscInt()
    {
        Value = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OscInt"/> class with the specified integer value.
    /// </summary>
    /// <param name="value">The integer value to be wrapped.</param>
    public OscInt(int value)
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
        return OscTypeTag.Int32;
    }

    public int CompareTo(OscInt other)
    {
        return Value.CompareTo(other.Value);
    }
    
    public bool Equals(OscInt other)
    {
        return other.Value == Value;
    }
    
    public static bool operator ==(OscInt left, OscInt right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscInt left, OscInt right)
    {
        return !left.Equals(right);
    }
    
}