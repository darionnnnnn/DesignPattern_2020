using System;
using System.Collections.Generic;

namespace _09_Behavioral_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            StrategyFactory strategyFactory = new StrategyFactory();

            var context_A = strategyFactory.GetStrategyByType(StrategyType.Type_A);
            context_A.Run();

            Console.WriteLine("--");

            var context_B = strategyFactory.GetStrategyByType(StrategyType.Type_B);
            context_B.Run();

            Console.ReadLine();
        }

        enum StrategyType
        {
            Type_A,
            Type_B
        }

        /// <summary>
        /// 4. 封裝
        /// </summary>
        class StrategyFactory
        {
            Dictionary<StrategyType, Context> _Strategys = new Dictionary<StrategyType, Context>();
            public StrategyFactory()
            {
                _Strategys.Add(StrategyType.Type_A, new Context(new ConcreteStrategy_A()));
                _Strategys.Add(StrategyType.Type_B, new Context(new ConcreteStrategy_B()));
            }

            public Context GetStrategyByType(StrategyType strategyType)
            {
                if (_Strategys.TryGetValue(strategyType, out Context context))
                {
                    return context;
                }

                return null;
            }
        }

        /// <summary>
        /// 3. 使用
        /// </summary>
        class Context
        {
            private Strategy _strategy;

            public Context(Strategy strategy)
            {
                _strategy = strategy;
            }

            public void Run()
            {
                _strategy.DoSomething();
                _strategy.DoOtherThings();
            }
        }

        /// <summary>
        /// 1. 定義
        /// </summary>
        abstract class Strategy
        {
            public abstract void DoSomething();

            public IExtension OtherThings { get; set; }

            public void DoOtherThings()
            {
                OtherThings.DoOtherThings();
            }
        }

        /// <summary>
        /// 2. 創建
        /// </summary>
        class ConcreteStrategy_A : Strategy
        {
            public ConcreteStrategy_A()
            {
                OtherThings = new Extension_2();
            }

            public override void DoSomething()
            {
                Console.WriteLine("ConcreteStrategy_A");
            }
        }

        /// <summary>
        /// 2. 創建
        /// </summary>
        class ConcreteStrategy_B : Strategy
        {
            public ConcreteStrategy_B()
            {
                OtherThings = new Extension_1();
            }

            public override void DoSomething()
            {
                Console.WriteLine("ConcreteStrategy_B");
            }
        }

        /// <summary>
        /// 擴充
        /// </summary>
        interface IExtension
        {
            void DoOtherThings();
        }

        class Extension_1 : IExtension
        {
            public void DoOtherThings()
            {
                Console.WriteLine("執行擴充");
            }
        }

        class Extension_2 : IExtension
        {
            public void DoOtherThings()
            {
                Console.WriteLine("無擴充");
            }
        }
    }
}
