using System;
using Buildetech.OscCore;
using MiniNtp;

namespace Buildetech.OscKit.Types;

public class OscTimestamp : IOscWriteable, IEquatable<OscTimestamp>, IComparable<OscTimestamp>
{
    
    public DateTime Value { get; set; }
    
    public OscTimestamp()
    {
        Value = DateTime.UtcNow;
    }

    public OscTimestamp(DateTime dateTime)
    {
        Value = dateTime;
    }
    
    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        var ts = new NtpTimestamp(Value);
        writer.Write(ts);
    }
    
    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.TimeTag;
    }
    
    public int CompareTo(OscTimestamp other)
    {
        return Value.CompareTo(other.Value);
    }
    
    public bool Equals(OscTimestamp other)
    {
        return Value.Equals(other.Value);
    }
    
    public static bool operator ==(OscTimestamp left, OscTimestamp right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscTimestamp left, OscTimestamp right)
    {
        return !left.Equals(right);
    }
    
}