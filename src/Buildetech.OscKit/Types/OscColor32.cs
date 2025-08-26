using System;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Types
{
    public class OscColor32 : IEquatable<OscColor32>, IOscWriteable
    {

        private Buildetech.OscCore.UnityObjects.Color32 _color32;

        public OscColor32(byte r, byte g, byte b, byte a)
        {
            _color32 = new Buildetech.OscCore.UnityObjects.Color32(r, g, b, a);
        }

        internal OscColor32(Buildetech.OscCore.UnityObjects.Color32 color32)
        { 
            _color32 = color32;
        }

        internal OscCore.UnityObjects.Color32 GetColor32()
        {
            return _color32;
        }

        public byte Get(int index)
        {
            return _color32[index];
        }

        public void Set(int index, byte value)
        {
            _color32[index] = value;
        }
        
        public byte R { get => _color32.r; set => _color32.r = value; }
        public byte G { get => _color32.g; set => _color32.g = value; }
        public byte B { get => _color32.b; set => _color32.b = value; }
        public byte A { get => _color32.a; set => _color32.a = value; }

        public string ToString()
        {
            return _color32.ToString();
        }
        
        public string ToString(string format)
        {
            return _color32.ToString(format);
        }
        
        /// <inheritdoc />
        public void WriteTo(OscWriter writer)
        {
            writer.Write(_color32);
        }
        
        /// <inheritdoc />
        public OscTypeTag GetOscTypeTag()
        {
            return OscTypeTag.Color32;
        }
        
        public bool Equals(OscColor32 other)
        {
            return _color32.r == other._color32.r &&
                   _color32.g == other._color32.g &&
                   _color32.b == other._color32.b &&
                   _color32.a == other._color32.a;
        }
        
        public static bool operator == (OscColor32? left, OscColor32 right) => left.Equals(right);
        
        public static bool operator != (OscColor32 left, OscColor32 right) => !left.Equals(right);
        
    }
}