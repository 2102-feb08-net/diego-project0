using System;
using Xunit;

namespace Core.Test
{
    public class CoreCustomerTest
    {
        [Theory]
        [InlineData("", "Albatros")]
        [InlineData("James", "")]
        public void ValidateNameNullName(string fname, string lname)
        {
            // Arrange
            Core.Customer tester = new Customer();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => tester.ValidateName(fname, lname));
        }

        [Fact]
        public void ValidateNameNumericName()
        {
            // Arrange
            string fname = "Cr00s";
            string lname = "F13lds";
            Core.Customer tester = new Customer();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tester.ValidateName(fname, lname));

        }

    }
}
