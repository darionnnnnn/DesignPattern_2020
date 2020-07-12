using System;

namespace _05_Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            facade.Method_124();
            Console.WriteLine("");
            Console.WriteLine("");
            facade.Method_23();

            Console.ReadLine();
        }

        class SubSystem_1
        {
            public void Method_1()
            {
                Console.WriteLine("SubSystem_1 Method");
            }
        }

        class SubSystem_2
        {
            public void Method_2()
            {
                Console.WriteLine("SubSystem_2 Method");
            }
        }

        class SubSystem_3
        {
            public void Method_3()
            {
                Console.WriteLine("SubSystem_3 Method");
            }
        }

        class SubSystem_4
        {
            public void Method_4()
            {
                Console.WriteLine("SubSystem_4 Method");
            }
        }

        /// <summary>
        /// The 'Facade' class
        /// </summary>
        class Facade
        {
            private SubSystem_1 _SubSystem_1;
            private SubSystem_2 _SubSystem_2;
            private SubSystem_3 _SubSystem_3;
            private SubSystem_4 _SubSystem_4;

            public Facade()
            {
                _SubSystem_1 = new SubSystem_1();
                _SubSystem_2 = new SubSystem_2();
                _SubSystem_3 = new SubSystem_3();
                _SubSystem_4 = new SubSystem_4();
            }

            public void Method_124()
            {
                Console.WriteLine("Method_1 & Method_2 & Method_4");
                Console.WriteLine("");
                _SubSystem_1.Method_1();
                _SubSystem_2.Method_2();
                _SubSystem_4.Method_4();
            }

            public void Method_23()
            {
                Console.WriteLine("Method_2 & Method_3");
                Console.WriteLine("");
                _SubSystem_2.Method_2();
                _SubSystem_3.Method_3();
            }
        }
    }
}
