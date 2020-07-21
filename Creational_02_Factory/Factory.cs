using System;
using System.Collections.Generic;
using System.Text;

namespace Creational_02_Factory
{
    class Factory
    {
        public void Run()
        {
            ProductFactory product1 = new Product1();
            product1.GetProductType();

            ProductFactory product2 = new Product2();
            product2.GetProductType();
        }

        public interface ProductFactory
        {
            void GetProductType();
        }

        public class Product1 : ProductFactory
        {
            public void GetProductType()
            {
                Console.WriteLine("Product 1");
            }
        }

        public class Product2 : ProductFactory
        {
            public void GetProductType()
            {
                Console.WriteLine("Product 2");
            }
        }
    }
}