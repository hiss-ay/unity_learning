using System;
using System.Collections.Generic;

namespace unity_learning.Encapsulation.Ex2
{
    public class Cart
    {
        private readonly Warehouse _warehouse;
        private readonly Dictionary<IProduct, int> _products;
        
        public Cart(Warehouse warehouse)
        {
            _products = new Dictionary<IProduct, int>();
            _warehouse = warehouse ?? 
                         throw new ArgumentNullException(nameof(warehouse));
        }
        
        public void AddToCart(IProduct product, int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count), "The amount of product must be greater than zero.");

            _warehouse.RemoveFromStock(product, count);
            
            if (_products.ContainsKey(product))
                _products[product] += count;
            else
                _products[product] = count;
        }

        public void RemoveFromCart(IProduct product, int count)
        {
            if (_products.ContainsKey(product))
            {
                if (_products[product] >= count)
                {
                    _products[product] -= count;
                    if (_products[product] == 0)
                        _products.Remove(product);
                    
                    _warehouse.AddToStock(product, count);
                }
                else
                {
                    throw new ArgumentException("Not enough count in cart.");
                }
            }
            else
            {
                throw new ArgumentException("Product not found in cart.");
            }
        }
        
        public int GetProductCount(IProduct product)
        {
            return _products.ContainsKey(product) ? _products[product] : 0;
        }
    }
}