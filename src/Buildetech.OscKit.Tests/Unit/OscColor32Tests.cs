
namespace Buildetech.OscKit.Types.Tests.Unit
{
    public class OscColor32Tests
    {
        [Fact]
        public void Constructor_SetsRGBAValues()
        {
            // Arrange & Act
            var color = new OscColor32(10, 20, 30, 40);
            
            // Assert
            Assert.Equal(10, color.R);
            Assert.Equal(20, color.G);
            Assert.Equal(30, color.B);
            Assert.Equal(40, color.A);
        }
        
        [Fact]
        public void Properties_GetAndSetCorrectly()
        {
            // Arrange
            var color = new OscColor32(0, 0, 0, 0);
            
            // Act
            color.R = 100;
            color.G = 150;
            color.B = 200;
            color.A = 255;
            
            // Assert
            Assert.Equal(100, color.R);
            Assert.Equal(150, color.G);
            Assert.Equal(200, color.B);
            Assert.Equal(255, color.A);
        }
        
        [Theory]
        [InlineData(0, 10)]
        [InlineData(1, 20)]
        [InlineData(2, 30)]
        [InlineData(3, 40)]
        public void Get_ReturnsCorrectValueAtIndex(int index, byte expected)
        {
            // Arrange
            var color = new OscColor32(10, 20, 30, 40);
            
            // Act
            var result = color.Get(index);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData(0, 100)]
        [InlineData(1, 150)]
        [InlineData(2, 200)]
        [InlineData(3, 250)]
        public void Set_SetsCorrectValueAtIndex(int index, byte value)
        {
            // Arrange
            var color = new OscColor32(0, 0, 0, 0);
            
            // Act
            color.Set(index, value);
            
            // Assert
            Assert.Equal(value, color.Get(index));
        }
        
        [Fact]
        public void ToString_ReturnsExpectedString()
        {
            // Arrange
            var color = new OscColor32(100, 150, 200, 255);
            
            // Act
            var result = color.ToString();
            
            // Assert
            Assert.Equal("RGBA(100, 150, 200, 255)", result);
            
        }
        
        [Fact]
        public void ToStringWithFormat_ReturnsExpectedString()
        {
            // Arrange
            var color = new OscColor32(100, 150, 200, 255);
            
            // Act
            var result = color.ToString("F2");
            
            // Assert
            Assert.Equal("RGBA(100.00, 150.00, 200.00, 255.00)", result);
        }
        
        [Fact]
        public void Equals_ReturnsTrueForEqualColors()
        {
            // Arrange
            var color1 = new OscColor32(100, 150, 200, 255);
            var color2 = new OscColor32(100, 150, 200, 255);
            
            // Act & Assert
            Assert.True(color1.Equals(color2));
        }
        
        [Fact]
        public void Equals_ReturnsFalseForDifferentColors()
        {
            // Arrange
            var color1 = new OscColor32(100, 150, 200, 255);
            var color2 = new OscColor32(101, 150, 200, 255);
            
            // Act & Assert
            Assert.False(color1.Equals(color2));
        }
        
        [Fact]
        public void EqualsOperator_ReturnsTrueForEqualColors()
        {
            // Arrange
            var color1 = new OscColor32(100, 150, 200, 255);
            var color2 = new OscColor32(100, 150, 200, 255);
            
            // Act & Assert
            Assert.True(color1 == color2);
        }
        
        [Fact]
        public void NotEqualsOperator_ReturnsTrueForDifferentColors()
        {
            // Arrange
            var color1 = new OscColor32(100, 150, 200, 255);
            var color2 = new OscColor32(100, 151, 200, 255);
            
            // Act & Assert
            Assert.True(color1 != color2);
        }
        
        [Fact]
        public void NotEqualsOperator_ReturnsFalseForEqualColors()
        {
            // Arrange
            var color1 = new OscColor32(100, 150, 200, 255);
            var color2 = new OscColor32(100, 150, 200, 255);
            
            // Act & Assert
            Assert.False(color1 != color2);
        }
        
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(255, 255, 255, 255)]
        [InlineData(128, 64, 32, 16)]
        public void Constructor_CreatesCorrectColor(byte r, byte g, byte b, byte a)
        {
            // Arrange & Act
            var color = new OscColor32(r, g, b, a);
            
            // Assert
            Assert.Equal(r, color.R);
            Assert.Equal(g, color.G);
            Assert.Equal(b, color.B);
            Assert.Equal(a, color.A);
        }
    }
}
