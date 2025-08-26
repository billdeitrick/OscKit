using System;
using Buildetech.OscKit.Types;
using Buildetech.OscKit.Types.Utils;

namespace Buildetech.OscKit
{
    public class OscMessageValues
    {
        
        private OscCore.OscMessageValues _values;

        internal OscMessageValues(OscCore.OscMessageValues values)
        {

            _values = values;

        }
        
        /// <summary>
        /// Maps an OscCore type tag to an OscKit type tag
        /// </summary>
        /// <param name="index">The index of the value in the received message.</param>
        /// <returns>The type tag at the specified index.</returns>
        public OscTypeTag GetTypeTag(int index)
        {

            var coreTag = _values.GetTypeTag(index);
            return OscMappingUtils.MapOscTypeTag(coreTag);
            
        }

        /// <summary>
        /// Runs a callback for each value in the message.
        /// </summary>
        /// <param name="action">The callback to run.</param>
        public void ForEachElement(Action<int, OscTypeTag> action)
        {
            
            _values.ForEachElement((index, tag) =>
            {
                action(
                    index,
                    OscMappingUtils.MapOscTypeTag(tag)
                );
            });
            
        }
        
        public char ReadAsciiCharElement(int index)
        {
            return _values.ReadAsciiCharElement(index);
        }

        public byte[] ReadBlobElement(int index)
        {
            return _values.ReadBlobElement(index);
        }
        
        public bool ReadBoolElement(int index)
        {
            return _values.ReadBooleanElement(index);
        }

        public OscColor32 ReadColor32Element(int index)
        {
            var c = _values.ReadColor32Element(index);
            return new OscColor32(c);
        }

        public float ReadReadFloatElement(int index)
        {
            return _values.ReadFloatElement(index);
        }
        
        public double ReadFloat64Element(int index)
        {
            return _values.ReadFloat64Element(index);
        }

        public int ReadIntElement(int index)
        {
            return _values.ReadIntElement(index);
        }
        
        public long ReadInt64Element(int index)
        {
            return _values.ReadInt64Element(index);
        }
        
        public OscMidiMessage ReadMidiElement(int index)
        {
            return new OscMidiMessage(_values.ReadMidiElement(index));
        }
        
        public bool ReadNilOrInfinitumElement(int index)
        {
            return _values.ReadNilOrInfinitumElement(index);
        }
        
        public string ReadStringElement(int index)
        {
            return _values.ReadStringElement(index);
        }
        
        public DateTime ReadTimestampElement(int index)
        {
            return _values.ReadTimestampElement(index).ToDateTime();
        }
    }
}