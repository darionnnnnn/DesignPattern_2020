using System;

namespace Behavioral_04_ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler handler_1 = new ConcreteHandler_1();
            Handler handler_2 = new ConcreteHandler_2();
            Handler handler_3 = new ConcreteHandler_3();

            handler_1.SetNextHandler(handler_2);
            handler_2.SetNextHandler(handler_3);

            int[] requests = { 1, -3, 5, 0, -2, 2, 4, -6 };

            foreach (var request in requests)
            {
                handler_1.HandleRequest(request);
            }

            Console.ReadLine();
        }

        abstract class Handler
        {
            protected Handler _NextHandler;

            public void SetNextHandler(Handler nextHandler)
            {
                _NextHandler = nextHandler;
            }

            public abstract void HandleRequest(int request);
        }

        class ConcreteHandler_1 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request < 0)
                {
                    Console.WriteLine($"class name: {GetType().Name}, handled request: {request}");
                    Console.WriteLine($"--");
                }
                else
                {
                    Console.WriteLine($"class name: {GetType().Name}, can't handle.");
                    _NextHandler?.HandleRequest(request);
                }
            }
        }

        class ConcreteHandler_2 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request == 0)
                {
                    Console.WriteLine($"class name: {GetType().Name}, handled request: {request}");
                    Console.WriteLine($"--");
                }
                else
                {
                    Console.WriteLine($"class name: {GetType().Name}, can't handle.");
                    _NextHandler?.HandleRequest(request);
                }
            }
        }

        class ConcreteHandler_3 : Handler
        {
            public override void HandleRequest(int request)
            {
                if (request > 0)
                {
                    Console.WriteLine($"class name: {GetType().Name}, handled request: {request}");
                    Console.WriteLine($"--");
                }
                else
                {
                    Console.WriteLine($"class name: {GetType().Name}, can't handle.");
                    _NextHandler?.HandleRequest(request);
                }
            }
        }
    }
}