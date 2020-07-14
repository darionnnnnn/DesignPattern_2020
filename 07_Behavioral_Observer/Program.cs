using System;
using System.Collections.Generic;

namespace _07_Behavioral_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Sync sync = new Sync();
            sync.Run();

            Console.ReadLine();
        }
    }
}