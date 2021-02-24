using System;
using Xunit;

namespace Core.Test
{
    public class CoreProductTest
    {
        [Fact]
        public void ConstructorNoType()
        {
            // Arrange
            Core.Product tester = new Product("", "iPod", 7, 30.0M, 1);

            // Act & Assert
            Assert.Equal("None", tester.Type);
        }
    }
}
