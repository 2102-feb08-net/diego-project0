using System;
using Xunit;

namespace Core.Test
{
    public class CoreOrderTest
    {
        [Fact]
        public void AddToCartNoQuantity()
        {
            // Arrange
            Core.Order order = new Order();
            Product p = new Product("Accessories", "Logitech Mouse", 9, 5.00M, 0);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => order.AddToCart(p,0));

        }
    }
}
