using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Creational_02_Factory
{
    public class SimpleFactory
    {
        private Factory _factory { get; }
        public SimpleFactory()
        {
            _factory = new Factory();
        }

        public void Run(ProductType productType)
        {
            var product = _factory.GetProduct(productType);

            product.Step_1();
            product.Step_2();
            product.Step_3();
        }

        /// <summary>
        /// 簡單工廠
        /// </summary>
        public class Factory
        {
            public IProduct GetProduct(ProductType productType)
            {
                return productType switch
                       {
                           ProductType.TypeA => (IProduct) new ConcreteProduct_A(),
                           ProductType.TypeB => new ConcreteProduct_B(),
                           _                  => null
                       };
            }
        }

        public interface IProduct
        {
            void Step_1();
            void Step_2();
            void Step_3();
        }

        public enum ProductType
        {
            TypeA,
            TypeB
        }

        public class ConcreteProduct_A : IProduct
        {
            public void Step_1()
            {
                Console.WriteLine("實作 A, Step 1");
            }
            public void Step_2()
            {
                Console.WriteLine("實作 A, Step 2");
            }
            public void Step_3()
            {
                Console.WriteLine("實作 A, Step 3");
            }
        }

        public class ConcreteProduct_B : IProduct
        {
            public void Step_1()
            {
                Console.WriteLine("實作 B, Step 1");
            }
            public void Step_2()
            {
                Console.WriteLine("實作 B, Step 2");
            }
            public void Step_3()
            {
                Console.WriteLine("實作 B, Step 3");
            }
        }
    }
}
