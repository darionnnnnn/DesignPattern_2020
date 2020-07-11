using System;

namespace _03_Decorator
{
    public class Example_2
    {
        public interface IAction
        {
            void Do();
        }

        public abstract class ActionBase : IAction
        {
            protected IAction _previousStep;

            public abstract void Do();

            public virtual void SetDecorated(IAction action)
            {
                _previousStep = action;
            }
        }

        /// <summary>
        /// 蛋糕
        /// </summary>
        public class Cake : IAction
        {
            public void Do()
            {
                Console.WriteLine("放上 底層蛋糕");
            }
        }

        /// <summary>
        /// 夾層蛋糕
        /// </summary>
        public class MiddleCake : ActionBase
        {
            public override void Do()
            {
                _previousStep.Do();

                Console.WriteLine("放上 夾層蛋糕");
            }
        }

        /// <summary>
        /// 布丁
        /// </summary>
        public class Putting : ActionBase
        {
            public override void Do()
            {
                _previousStep.Do();

                Console.WriteLine("放上 布丁");
            }
        }

        /// <summary>
        /// 卡士達醬
        /// </summary>
        public class Custard : ActionBase
        {
            public override void Do()
            {
                _previousStep.Do();

                Console.WriteLine("放上 卡士達醬");
            }
        }

        /// <summary>
        /// 鮮奶油
        /// </summary>
        public class Cream : ActionBase
        {
            public override void Do()
            {
                _previousStep.Do();

                Console.WriteLine("放上 鮮奶油");
            }
        }

        /// <summary>
        /// 水果
        /// </summary>
        public class Fruit : ActionBase
        {
            public override void Do()
            {
                _previousStep.Do();

                Console.WriteLine("放上 水果");
            }
        }

        public class DecorateFactory
        {
            IAction _original;

            public DecorateFactory(IAction original)
            {
                _original = original;
            }

            public DecorateFactory NextStep(ActionBase action)
            {
                action.SetDecorated(_original);
                _original = action;
                return this;
            }

            public IAction GetProcess()
            {
                return _original;
            }
        }
    }
}
