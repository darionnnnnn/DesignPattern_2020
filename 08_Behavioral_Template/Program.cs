using System;

namespace _08_Behavioral_Template
{
    class Program
    {
        static void Main(string[] args)
        {
            //Template_Run();

            Callback callback = new Callback();
            callback.Run();

            Console.ReadLine();
        }

        private static void Template_Run()
        {
            AbstractClass aA = new Class_A();
            aA.TemplateMethod();

            AbstractClass aB = new Class_B();
            aB.TemplateMethod();
        }

        /// <summary>
        /// 將共用部分抽出至父類別
        /// </summary>
        abstract class AbstractClass
        {
            public abstract void FirstOperation();
            public abstract void SecondOperation();

            // Template method
            public void TemplateMethod()
            {
                FirstOperation();
                SecondOperation();
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// 實作 AbstractClass 的 Class_A
        /// </summary>
        class Class_A : AbstractClass
        {
            public override void FirstOperation()
            {
                Console.WriteLine("Class_A, FirstOperation()");
            }
            public override void SecondOperation()
            {
                Console.WriteLine("Class_A, SecondOperation()");
            }
        }

        /// <summary>
        /// 實作 AbstractClass 的 Class_B
        /// </summary>
        class Class_B : AbstractClass
        {
            public override void FirstOperation()
            {
                Console.WriteLine("Class_B, FirstOperation()");
            }
            public override void SecondOperation()
            {
                Console.WriteLine("Class_B, SecondOperation()");
            }
        }
    }
}
