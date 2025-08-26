using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscFloat : IOscWriteable, IEquatable<OscFloat>, IComparable<OscFloat>
{
    
    public float Value { get; set; }
    
    /// <summary>
    /// Initialize a new instance of the class with zero value.
    /// </summary>
    public OscFloat()
    {
        Value = 0.0f;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OscFloat"/> class with the specified float value.
    /// </summary>
    /// <param name="value">The float value to be wrapped.</param>
    public OscFloat(float value)
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
        return OscTypeTag.Float32;
    }
    
    public int CompareTo(OscFloat other)
    {
        return Value.CompareTo(other.Value);
    }
    
    public bool Equals(OscFloat other)
    {
        return other.Value.Equals(Value);
    }
    
    public static bool operator ==(OscFloat left, OscFloat right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscFloat left, OscFloat right)
    {
        return !left.Equals(right);
    }
    
}