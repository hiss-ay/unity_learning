using System;

namespace unity_learning.Encapsulation.Ex2
{
    public class Shop
    {
        private readonly Warehouse _warehouse;

        public Shop(Warehouse warehouse)
        {
            _warehouse = warehouse ?? 
                         throw new ArgumentNullException(nameof(warehouse));
        }

        public Cart CreateCart()
        {
            return new Cart(_warehouse);
        }
    }
}