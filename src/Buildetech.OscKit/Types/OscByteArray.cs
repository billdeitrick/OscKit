using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscByteArray : IOscWriteable, IEquatable<OscByteArray>, IComparable<OscByteArray>
{
    
    public byte[] Bytes { get; set; }
    
    public OscByteArray()
    {
        Bytes = Array.Empty<byte>();
    }
    
    public OscByteArray(byte[] bytes)
    {
        Bytes = bytes;
    }
    
    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        writer.Write(Bytes, Bytes.Length, 0);
    }

    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.Blob;
    }

    public int CompareTo(OscByteArray other)
    {
        if (Bytes.Length != other.Bytes.Length)
            return Bytes.Length.CompareTo(other.Bytes.Length);
        
        for (int i = 0; i < Bytes.Length; i++)
        {
            int comparison = Bytes[i].CompareTo(other.Bytes[i]);
            if (comparison != 0)
                return comparison;
        }
        
        return 0;
    }
    
    public bool Equals(OscByteArray other)
    {
        if (Bytes.Length != other.Bytes.Length)
            return false;
        
        for (int i = 0; i < Bytes.Length; i++)
        {
            if (Bytes[i] != other.Bytes[i])
                return false;
        }
        
        return true;
    }
    
    public static bool operator ==(OscByteArray left, OscByteArray right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscByteArray left, OscByteArray right)
    {
        return !left.Equals(right);
    }
    
}