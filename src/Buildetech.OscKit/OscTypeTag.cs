using Buildetech.OscCore;

namespace Buildetech.OscKit
{
    /// <summary>
    /// Represents the supported OSC type tags in Buildetech.OscKit.
    /// These tags are used to identify the type of each element in an OSC message.
    /// </summary>
    public enum OscTypeTag
    {
        /// <summary>False boolean value (F, non-standard).</summary>
        False = TypeTag.False,

        /// <summary>Infinitum value (I, non-standard).</summary>
        Infinitum = TypeTag.Infinitum,

        /// <summary>Nil/null value (N, non-standard).</summary>
        Nil = TypeTag.Nil,

        /// <summary>Alternate type string (S, non-standard).</summary>
        AltTypeString = TypeTag.AltTypeString,

        /// <summary>True boolean value (T, non-standard).</summary>
        True = TypeTag.True,

        /// <summary>Array start ([, non-standard).</summary>
        ArrayStart = TypeTag.ArrayStart,

        /// <summary>Array end (], non-standard).</summary>
        ArrayEnd = TypeTag.ArrayEnd,

        /// <summary>Binary data blob (b, STANDARD).</summary>
        Blob = TypeTag.Blob,

        /// <summary>ASCII character (c, non-standard).</summary>
        AsciiChar32 = TypeTag.AsciiChar32,

        /// <summary>64-bit floating point number (d, non-standard).</summary>
        Float64 = TypeTag.Float64,

        /// <summary>32-bit floating point number (f, STANDARD).</summary>
        Float32 = TypeTag.Float32,

        /// <summary>64-bit integer (h, non-standard).</summary>
        Int64 = TypeTag.Int64,

        /// <summary>32-bit integer (i, STANDARD).</summary>
        Int32 = TypeTag.Int32,

        /// <summary>Midi message (m, non-standard).</summary>
        Midi = TypeTag.MIDI,

        /// <summary>32-bit RGBA color (r, non-standard).</summary>
        Color32 = TypeTag.Color32,

        /// <summary>String value (s, STANDARD).</summary>
        String = TypeTag.String,

        /// <summary>OSC time tag (t, non-standard).</summary>
        TimeTag = TypeTag.TimeTag,
    }
}