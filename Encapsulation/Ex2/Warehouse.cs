using System;
using System.Collections.Generic;

namespace unity_learning.Encapsulation.Ex2
{
    public class Warehouse
    {
        private readonly Dictionary<IProduct, int> _stock = new Dictionary<IProduct, int>();

        //These methods can be put in a separate interface
        public void AddToStock(IProduct product, int count)
        {
            if (_stock.ContainsKey(product))
                _stock[product] += count;
            else
                _stock.Add(product, count);
        }

        public void RemoveFromStock(IProduct product, int count)
        {
            if (CanDelivery(product, count))
            {
                _stock[product] -= count;
                if (_stock[product] == 0)
                    _stock.Remove(product);
            }
        }
        
        public int GetStockCount(IProduct product)
        {
            return _stock.ContainsKey(product) ? _stock[product] : 0;
        }

        private bool CanDelivery(IProduct product, int count)
        {
            if (!_stock.ContainsKey(product))
                throw new ArgumentException($"This product {product.Name} is out of stock");
            
            if (_stock[product] < count)
                throw new ArgumentException($"Not enough product {product.Name} in stock.");

            return true;
        }
    }
}