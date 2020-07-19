using System;

namespace Creational_02_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactory simpleFactory = new SimpleFactory();
            simpleFactory.Run(SimpleFactory.ProductType.TypeA);
            Console.WriteLine("--");
            simpleFactory.Run(SimpleFactory.ProductType.TypeB);

            Console.ReadLine();
        }
    }
}
