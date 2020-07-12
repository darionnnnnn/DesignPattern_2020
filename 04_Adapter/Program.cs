using System;

namespace _04_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Adapter adapter = new Adapter(new Adaptee());
            adapter.Request();

            Console.ReadLine();
        }
    }

    interface ITarget
    {
        void Request();
    }

    class Adaptee
    {
        public void AdapteeRequest()
        {
            Console.WriteLine("Hello Adaptee!!");
        }
    }

    class Adapter : ITarget
    {
        protected Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void Request()
        {
            if (_adaptee != null)
                _adaptee.AdapteeRequest();
        }
    }
}