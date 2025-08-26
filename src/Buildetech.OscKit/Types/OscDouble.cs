using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscDouble : IOscWriteable, IEquatable<OscDouble>, IComparable<OscDouble>
{
    
    public Double Value { get; set; }

    /// <summary>
    /// Initialize a new instance of the class with zero value.
    /// </summary>
    public OscDouble()
    {
        Value = 0;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OscDouble"/> class with the specified double value.
    /// </summary>
    /// <param name="value">The double value to be wrapped.</param>
    public OscDouble(double value)
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
        return OscTypeTag.Float64;
    }
    
    public int CompareTo(OscDouble other)
    {
        return Value.CompareTo(other.Value);
    }
    
    public bool Equals(OscDouble other)
    {
        return other.Value.Equals(Value);
    }
    
    public static bool operator ==(OscDouble left, OscDouble right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(OscDouble left, OscDouble right)
    {
        return !left.Equals(right);
    }

}