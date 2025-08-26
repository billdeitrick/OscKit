
namespace Buildetech.OscKit.Types.Tests.Unit
{
    public class OscMidiMessageTests
    {
        [Fact]
        public void Constructor_WithBytesAndOffset_CreatesInstanceWithCorrectValues()
        {
            // Arrange
            byte[] bytes = new byte[] { 0x01, 0x90, 0x40, 0x7F };
            int offset = 0;
            
            // Act
            var midiMessage = new OscMidiMessage(bytes, offset);
            
            // Assert
            string expected = "Port ID: 1, Status: 144, Data 1: 64 , 2: 127";
            Assert.Equal(expected, midiMessage.ToString());
        }
        
        [Fact]
        public void Constructor_WithIndividualBytes_CreatesInstanceWithCorrectValues()
        {
            // Arrange
            byte portId = 1;
            byte status = 0x90; // Note On
            byte data1 = 0x40;  // Note number (middle C)
            byte data2 = 0x7F;  // Velocity (max)
            
            // Act
            var midiMessage = new OscMidiMessage(portId, status, data1, data2);
            
            // Assert
            string expected = "Port ID: 1, Status: 144, Data 1: 64 , 2: 127";
            Assert.Equal(expected, midiMessage.ToString());
        }
        
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            // Arrange
            byte portId = 1;
            byte status = 0x90; // Note On
            byte data1 = 0x40;  // Note number (middle C)
            byte data2 = 0x7F;  // Velocity (max)
            var midiMessage = new OscMidiMessage(portId, status, data1, data2);
            
            // Act
            var result = midiMessage.ToString();
            
            // Assert
            string expected = "Port ID: 1, Status: 144, Data 1: 64 , 2: 127";
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Equals_ReturnsTrueForEqualMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            var message2 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            
            // Act & Assert
            Assert.True(message1.Equals(message2));
            Assert.Equal(message1.ToString(), message2.ToString());
        }
        
        [Fact]
        public void Equals_ReturnsFalseForDifferentMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            var message2 = new OscMidiMessage(1, 0x90, 0x41, 0x7F); // Different note number
            
            // Act & Assert
            Assert.False(message1.Equals(message2));
            Assert.NotEqual(message1.ToString(), message2.ToString());
            Assert.Equal("Port ID: 1, Status: 144, Data 1: 64 , 2: 127", message1.ToString());
            Assert.Equal("Port ID: 1, Status: 144, Data 1: 65 , 2: 127", message2.ToString());
        }
        
        [Fact]
        public void EqualsObject_ReturnsTrueForEqualMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            object message2 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            
            // Act & Assert
            Assert.True(message1.Equals(message2));
            Assert.Equal(message1.ToString(), ((OscMidiMessage)message2).ToString());
        }
        
        [Fact]
        public void EqualsObject_ReturnsFalseForDifferentTypes()
        {
            // Arrange
            var message = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            object differentObject = "Not a OscMidiMessage";
            
            // Act & Assert
            Assert.False(message.Equals(differentObject));
        }
        
        [Fact]
        public void GetHashCode_ReturnsSameValueForEqualMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            var message2 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            
            // Act
            var hashCode1 = message1.GetHashCode();
            var hashCode2 = message2.GetHashCode();
            
            // Assert
            Assert.Equal(hashCode1, hashCode2);
            Assert.Equal(message1.ToString(), message2.ToString());
        }
        
        [Fact]
        public void EqualityOperator_ReturnsTrueForEqualMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            var message2 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            
            // Act & Assert
            Assert.True(message1 == message2);
            Assert.Equal(message1.ToString(), message2.ToString());
        }
        
        [Fact]
        public void InequalityOperator_ReturnsTrueForDifferentMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            var message2 = new OscMidiMessage(1, 0x90, 0x41, 0x7F); // Different note number
            
            // Act & Assert
            Assert.True(message1 != message2);
            Assert.NotEqual(message1.ToString(), message2.ToString());
            Assert.Equal("Port ID: 1, Status: 144, Data 1: 64 , 2: 127", message1.ToString());
            Assert.Equal("Port ID: 1, Status: 144, Data 1: 65 , 2: 127", message2.ToString());
        }
        
        [Fact]
        public void InequalityOperator_ReturnsFalseForEqualMessages()
        {
            // Arrange
            var message1 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            var message2 = new OscMidiMessage(1, 0x90, 0x40, 0x7F);
            
            // Act & Assert
            Assert.False(message1 != message2);
            Assert.Equal(message1.ToString(), message2.ToString());
        }
        
        [Theory]
        [InlineData(1, 0x90, 0x40, 0x7F, "Port ID: 1, Status: 144, Data 1: 64 , 2: 127")]  // Note On, middle C, max velocity
        [InlineData(0, 0x80, 0x3C, 0x00, "Port ID: 0, Status: 128, Data 1: 60 , 2: 0")]    // Note Off, C3, zero velocity
        [InlineData(2, 0xB0, 0x07, 0x64, "Port ID: 2, Status: 176, Data 1: 7 , 2: 100")]   // Control Change, volume, mid value
        public void Constructor_WithDifferentValues_CreatesInstanceWithCorrectValues(byte portId, byte status, byte data1, byte data2, string expected)
        {
            // Arrange & Act
            var midiMessage = new OscMidiMessage(portId, status, data1, data2);
            
            // Assert
            Assert.Equal(expected, midiMessage.ToString());
        }
        
        [Fact]
        public void Constructor_WithByteArray_HandlesOffset()
        {
            // Arrange
            byte[] bytes = new byte[] { 0xFF, 0xFF, 0x01, 0x90, 0x40, 0x7F };
            int offset = 2; // Skip the first two bytes
            
            // Act
            var midiMessage = new OscMidiMessage(bytes, offset);
            
            // Assert
            string expected = "Port ID: 1, Status: 144, Data 1: 64 , 2: 127";
            Assert.Equal(expected, midiMessage.ToString());
        }
    }
}
