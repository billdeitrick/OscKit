using Buildetech.OscCore;

namespace Buildetech.OscKit.Types;

/// <summary>
/// Indicates an object is writeable to an OSC Writer instance.
/// </summary>
public interface IOscWriteable
{
    
    /// <summary>
    /// Writes the current object bytes to the supplied OscWriter instance.
    /// </summary>
    /// <param name="writer">The writer instance to which the current object should be written.</param>
    public void WriteTo(OscWriter writer);

    /// <summary>
    /// Get the type tag string for the current object.
    /// </summary>
    /// <returns>The type tag string for the current object.</returns>
    public OscTypeTag GetOscTypeTag();

}