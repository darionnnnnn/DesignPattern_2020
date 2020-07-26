using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Creational_03_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            Console.WriteLine("-- 1");
            Run();

            // 2
            Console.WriteLine("\n-- 2");
            var builder2 = new Builder_2();
            builder2.Run();

            Console.ReadLine();
        }

        static void Run()
        {
            Director director = new Director();

            IBuilder builder1 = new ConcreteBuilder1();
            IBuilder builder2 = new ConcreteBuilder2();

            director.Construct(builder1);
            Product product1 = builder1.GetProduct();
            product1.Show();

            director.Construct(builder2);
            Product product2 = builder2.GetProduct();
            product2.Show();
        }

        class Director
        {
            public void Construct(IBuilder builder)
            {
                builder.BuildFirstPart();
                builder.BuildSecondPart();
            }
        }

        interface IBuilder
        {
            void BuildFirstPart();
            void BuildSecondPart();
            Product GetProduct();
        }

        class ConcreteBuilder1 : IBuilder

        {
            private Product _product = new Product();

            public void BuildFirstPart()
            {
                _product.Add("Part A");
            }

            public void BuildSecondPart()
            {
                _product.Add("Part B");
            }

            public Product GetProduct()
            {
                return _product;
            }
        }

        class ConcreteBuilder2 : IBuilder
        {
            private Product _product = new Product();

            public void BuildFirstPart()
            {
                _product.Add("Part 1");
            }

            public void BuildSecondPart()
            {
                _product.Add("Part 2");
            }

            public Product GetProduct()
            {
                return _product;
            }
        }

        class Product
        {
            private List<string> _parts = new List<string>();

            public void Add(string part)
            {
                _parts.Add(part);
            }

            public void Show()
            {
                Console.WriteLine("\nProduct Parts -------");

                foreach (var part in _parts)
                {
                    Console.WriteLine(part);
                }
            }
        }
    }
}
