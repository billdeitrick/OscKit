using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscChar : IOscWriteable, IEquatable<OscChar>, IComparable<OscChar>
{
    
    public char Value { get; set; }

    /// <summary>
    /// Initialize a new instance of the class with zero value.
    /// </summary>
    public OscChar()
    {
        Value = Char.MinValue;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OscChar"/> class with the specified char value.
    /// </summary>
    /// <param name="value">The char value to be wrapped.</param>
    public OscChar(char value)
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
        return OscTypeTag.AsciiChar32;
    }

    public int CompareTo(OscChar other)
    {
        return Value.CompareTo(other.Value);
    }
    
    public bool Equals(OscChar other)
    {
        return other.Value == Value;
    }
    
    public static bool operator ==(OscChar left, OscChar right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscChar left, OscChar right)
    {
        return !left.Equals(right);
    }
    
}