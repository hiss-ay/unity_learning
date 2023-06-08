using System;
using NUnit.Framework;

namespace unity_learning.Encapsulation.Ex2
{
    [TestFixture]
    public class Tests
    {
        private Phone _phone;
        private Cart _cart;
        
        private readonly Warehouse _warehouse = new Warehouse();

        [SetUp]
        public void Setup()
        {
            _phone = new Phone("iPhone");
            
            _warehouse.AddToStock(_phone, 10);
            
            Shop shop = new Shop(_warehouse);
            _cart = shop.CreateCart();
        }

        [Test]
        public void AddToCart_AddsProductToCartAndRemovesFromStock()
        {
            int initialStockCount = _warehouse.GetStockCount(_phone);
            int initialCartCount = _cart.GetProductCount(_phone);
            int count = 3;

            _cart.AddToCart(_phone, count);

            int expectedStockCount = initialStockCount - count;
            int expectedCartCount = initialCartCount + count;

            Assert.AreEqual(expectedStockCount, _warehouse.GetStockCount(_phone));
            Assert.AreEqual(expectedCartCount, _cart.GetProductCount(_phone));
        }

        [Test]
        public void AddToCart_InvalidProduct()
        {
            var invalidProduct = new Phone("InvalidPhone");
            int count = 3;

            _cart.AddToCart(invalidProduct, count);
        }

        [Test]
        public void AddToCart_InvalidCount()
        {
            _cart.AddToCart(_phone, 0);
        }
        
        [Test]
        public void RemoveFromCart_RemovesProductFromCartAndAddsToStock()
        {
            _cart.AddToCart(_phone, 5);
            
            int initialStockCount = _warehouse.GetStockCount(_phone);
            int initialCartCount = _cart.GetProductCount(_phone);
            int count = 3;

            _cart.RemoveFromCart(_phone, count);

            int expectedStockCount = initialStockCount + count;
            int expectedCartCount = initialCartCount - count;

            Assert.AreEqual(expectedStockCount, _warehouse.GetStockCount(_phone));
            Assert.AreEqual(expectedCartCount, _cart.GetProductCount(_phone));
        }

        [Test]
        public void RemoveFromCart_InvalidProduct()
        {
            var invalidProduct = new Phone("InvalidPhone");
            int count = 3;

            _cart.RemoveFromCart(invalidProduct, count);
        }

        [Test]
        public void RemoveFromCart_InvalidCount()
        {
            _cart.RemoveFromCart(_phone, 0);
        }

        [Test]
        public void RemoveFromCart_NotEnoughCount()
        {
            _cart.AddToCart(_phone, 5);
            _cart.RemoveFromCart(_phone, 10);
        }
    }
}