using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

public class OscNil
{
    
    public OscNil()
    {
        // This class represents a nil value in OSC, which is typically used to indicate the absence of a value.
        // It does not contain any properties or methods, as it serves as a marker type.
    }
    
    /// <inheritdoc />
    public void WriteTo(OscWriter writer)
    {
        // No-op for Nil value
    }
    
    /// <inheritdoc />
    public OscTypeTag GetOscTypeTag()
    {
        return OscTypeTag.Nil;
    }
    
    public int CompareTo(OscNil other)
    {
        // Nil is considered equal to another Nil
        return 0;
    }
    
    public bool Equals(OscNil other)
    {
        // Nil is considered equal to another Nil
        return true;
    }
    
    public static bool operator ==(OscNil left, OscNil right)
    {
        return left.Equals(right);
    }
    
    public static bool operator !=(OscNil left, OscNil right)
    {
        return !left.Equals(right);
    }
    
}