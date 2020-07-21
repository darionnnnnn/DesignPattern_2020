using System;

namespace Creational_02_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // SimpleFactory
            // SimpleFactory simpleFactory = new SimpleFactory();
            // simpleFactory.Run(SimpleFactory.ProductType.TypeA);
            // Console.WriteLine("--");
            // simpleFactory.Run(SimpleFactory.ProductType.TypeB);

            // Factory
            Factory factory = new Factory();
            factory.Run();

            Console.ReadLine();
        }
    }
}
