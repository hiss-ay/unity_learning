using System;

namespace unity_learning.Encapsulation.Ex2
{
    public class Phone: IProduct
    {
        public string Name { get; }

        public Phone(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Product name cannot be empty", nameof(name));
            
            Name = name;
        }
    }
}