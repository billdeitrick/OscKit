using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscString : IOscWriteable, IEquatable<OscString>, IComparable<OscString>
{
    
    public string Value { get; set; }

    /// <summary>
    /// Initialize a new instance of the class with an empty string.
    /// </summary>
    public OscString()
    {
        Value = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OscString"/> class with the specified string value.
    /// </summary>
    /// <param name="value">The string value to be wrapped.</param>
    public OscString(string value)
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
        return OscTypeTag.String;
    }

    public bool Equals(OscString other)
    {
        return other.Value == Value;
    }
    
    public static bool operator ==(OscString left, OscString right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscString left, OscString right)
    {
        return !left.Equals(right);
    }
    
    public int CompareTo(OscString other)
    {
        return String.Compare(Value, other.Value, StringComparison.Ordinal);
    }
    
}