using System;

namespace Creational_01_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = Singleton.GetInstance();
            var s2 = Singleton.GetInstance();

            Console.WriteLine(s1 == s2 ? "實體相同。" : "實體不同。");

            Console.ReadLine();
        }

        class Singleton
        {
            private static Singleton _instance;

            // 避免由外部直接 new 出，將建構子設為 private
            private Singleton()
            {
            }

            public static Singleton GetInstance()
            {
                // not thread safety.
                return _instance ??= new Singleton();
            }
        }
    }
}
