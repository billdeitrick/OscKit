using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types
{
    public class OscMidiMessage : IEquatable<OscMidiMessage>, IOscWriteable
    {
        
        private Buildetech.OscCore.MidiMessage _midiMessage;

        public OscMidiMessage(byte[] bytes, int offset)
        {
            _midiMessage = new Buildetech.OscCore.MidiMessage(bytes, offset);
        }

        public OscMidiMessage(byte portId, byte status, byte data1, byte data2)
        {
            _midiMessage = new Buildetech.OscCore.MidiMessage(portId, status, data1, data2);
        }

        internal OscMidiMessage(Buildetech.OscCore.MidiMessage midiMessage)
        {
            _midiMessage = midiMessage;
        }
        
        internal Buildetech.OscCore.MidiMessage GetMidiMessage()
        {
            return _midiMessage;
        }

        public override string ToString()
        {
            return _midiMessage.ToString();
        }

        public void WriteTo(OscWriter writer)
        {
            writer.Write(_midiMessage);
        }
        
        /// <inheritdoc />
        public OscTypeTag GetOscTypeTag()
        {
            return OscTypeTag.Midi;
        }

        public bool Equals(OscMidiMessage other)
        {
            return _midiMessage.Equals(other._midiMessage);
        }

        public override bool Equals(object obj)
        {
            return obj is OscMidiMessage other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _midiMessage.GetHashCode();
        }

        public static bool operator ==(OscMidiMessage left, OscMidiMessage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(OscMidiMessage left, OscMidiMessage right)
        {
            return !left.Equals(right);
        }
        
    }
}