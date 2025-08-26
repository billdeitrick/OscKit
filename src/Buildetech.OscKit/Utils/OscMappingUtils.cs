using System;
using Buildetech.OscCore;
using Buildetech.OscKit.Types;

namespace Buildetech.OscKit.Types.Utils
{
    internal static class OscMappingUtils
    {
        internal static OscTypeTag MapOscTypeTag(TypeTag typeTag)
        {
            return typeTag switch
            {
                TypeTag.False         => OscTypeTag.False,
                TypeTag.Infinitum     => OscTypeTag.Infinitum,
                TypeTag.Nil           => OscTypeTag.Nil,
                TypeTag.AltTypeString => OscTypeTag.AltTypeString,
                TypeTag.True          => OscTypeTag.True,
                TypeTag.ArrayStart    => OscTypeTag.ArrayStart,
                TypeTag.ArrayEnd      => OscTypeTag.ArrayEnd,
                TypeTag.Blob          => OscTypeTag.Blob,
                TypeTag.AsciiChar32   => OscTypeTag.AsciiChar32,
                TypeTag.Float64       => OscTypeTag.Float64,
                TypeTag.Float32       => OscTypeTag.Float32,
                TypeTag.Int64         => OscTypeTag.Int64,
                TypeTag.Int32         => OscTypeTag.Int32,
                TypeTag.MIDI          => OscTypeTag.Midi,
                TypeTag.Color32       => OscTypeTag.Color32,
                TypeTag.String        => OscTypeTag.String,
                TypeTag.TimeTag       => OscTypeTag.TimeTag,
                _ => throw new ArgumentOutOfRangeException(nameof(typeTag), typeTag, null)
            };
        }
        
        internal static TypeTag MapCoreTypeTag(OscTypeTag oscTypeTag)
        {
            return oscTypeTag switch
            {
                OscTypeTag.False         => TypeTag.False,
                OscTypeTag.Infinitum     => TypeTag.Infinitum,
                OscTypeTag.Nil           => TypeTag.Nil,
                OscTypeTag.AltTypeString => TypeTag.AltTypeString,
                OscTypeTag.True          => TypeTag.True,
                OscTypeTag.ArrayStart    => TypeTag.ArrayStart,
                OscTypeTag.ArrayEnd      => TypeTag.ArrayEnd,
                OscTypeTag.Blob          => TypeTag.Blob,
                OscTypeTag.AsciiChar32   => TypeTag.AsciiChar32,
                OscTypeTag.Float64       => TypeTag.Float64,
                OscTypeTag.Float32       => TypeTag.Float32,
                OscTypeTag.Int64         => TypeTag.Int64,
                OscTypeTag.Int32         => TypeTag.Int32,
                OscTypeTag.Midi          => TypeTag.MIDI,
                OscTypeTag.Color32       => TypeTag.Color32,
                OscTypeTag.String        => TypeTag.String,
                OscTypeTag.TimeTag       => TypeTag.TimeTag,
                _ => throw new ArgumentOutOfRangeException(nameof(oscTypeTag), oscTypeTag, null)
            };
        }
    }
}