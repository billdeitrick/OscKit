using Xunit;
using Buildetech.OscCore;
using Buildetech.OscKit.Types;
using Buildetech.OscKit.Types.Utils;

namespace Buildetech.OscKit.Types.Tests.Unit
{
    public class OscMappingUtilsTests
    {
        [Theory]
        [InlineData(TypeTag.False,         OscTypeTag.False)]
        [InlineData(TypeTag.Infinitum,     OscTypeTag.Infinitum)]
        [InlineData(TypeTag.Nil,           OscTypeTag.Nil)]
        [InlineData(TypeTag.AltTypeString, OscTypeTag.AltTypeString)]
        [InlineData(TypeTag.True,          OscTypeTag.True)]
        [InlineData(TypeTag.ArrayStart,    OscTypeTag.ArrayStart)]
        [InlineData(TypeTag.ArrayEnd,      OscTypeTag.ArrayEnd)]
        [InlineData(TypeTag.Blob,          OscTypeTag.Blob)]
        [InlineData(TypeTag.AsciiChar32,   OscTypeTag.AsciiChar32)]
        [InlineData(TypeTag.Float64,       OscTypeTag.Float64)]
        [InlineData(TypeTag.Float32,       OscTypeTag.Float32)]
        [InlineData(TypeTag.Int64,         OscTypeTag.Int64)]
        [InlineData(TypeTag.Int32,         OscTypeTag.Int32)]
        [InlineData(TypeTag.MIDI,          OscTypeTag.Midi)]
        [InlineData(TypeTag.Color32,       OscTypeTag.Color32)]
        [InlineData(TypeTag.String,        OscTypeTag.String)]
        [InlineData(TypeTag.TimeTag,       OscTypeTag.TimeTag)]
        public void MapOscTypeTag_ReturnsExpectedOscTypeTag(TypeTag input, OscTypeTag expected)
        {
            var actual = OscMappingUtils.MapOscTypeTag(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(OscTypeTag.False,         TypeTag.False)]
        [InlineData(OscTypeTag.Infinitum,     TypeTag.Infinitum)]
        [InlineData(OscTypeTag.Nil,           TypeTag.Nil)]
        [InlineData(OscTypeTag.AltTypeString, TypeTag.AltTypeString)]
        [InlineData(OscTypeTag.True,          TypeTag.True)]
        [InlineData(OscTypeTag.ArrayStart,    TypeTag.ArrayStart)]
        [InlineData(OscTypeTag.ArrayEnd,      TypeTag.ArrayEnd)]
        [InlineData(OscTypeTag.Blob,          TypeTag.Blob)]
        [InlineData(OscTypeTag.AsciiChar32,   TypeTag.AsciiChar32)]
        [InlineData(OscTypeTag.Float64,       TypeTag.Float64)]
        [InlineData(OscTypeTag.Float32,       TypeTag.Float32)]
        [InlineData(OscTypeTag.Int64,         TypeTag.Int64)]
        [InlineData(OscTypeTag.Int32,         TypeTag.Int32)]
        [InlineData(OscTypeTag.Midi,          TypeTag.MIDI)]
        [InlineData(OscTypeTag.Color32,       TypeTag.Color32)]
        [InlineData(OscTypeTag.String,        TypeTag.String)]
        [InlineData(OscTypeTag.TimeTag,       TypeTag.TimeTag)]
        public void MapCoreTypeTag_ReturnsExpectedTypeTag(OscTypeTag input, TypeTag expected)
        {
            var actual = OscMappingUtils.MapCoreTypeTag(input);
            Assert.Equal(expected, actual);
        }
    }
}
