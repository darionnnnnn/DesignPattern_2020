using System;
using _03_Decorator;

namespace _23DecoratorPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Example_Phone_Run();
            // Example_2 example2 = new Example_2();
            // example2.Run();

            Console.ReadLine();
        }

        private static void Example_Phone_Run()
        {
            // 建立手機實體
            Phone phone = new Apple();

            // 先貼保護貼，再裝上手機殼，最後開機
            var phoneStatus = new TurnOnPower(new Case(new Sticker(phone)));
            phoneStatus.Do();
        }

        private static void Example_Cake_Run()
        {
            // 建立裝飾工廠
            var factroy = new Example_2.DecorateFactory(new Example_2.Cake());

            // 依據想要的步驟放上材料
            factroy.NextStep(new Example_2.Putting())
                   .NextStep(new Example_2.MiddleCake())
                   .NextStep(new Example_2.Custard())
                   .NextStep(new Example_2.MiddleCake())
                   .NextStep(new Example_2.Cream())
                   .NextStep(new Example_2.Fruit());

            // 執行
            Example_2.IAction action = factroy.GetProcess();
            action.Do();
        }
    }

    /// <summary>
    /// 裝飾者模式中的抽象元件類
    /// </summary>
    public abstract class Phone
    {
        public abstract void Do();
    }

    /// <summary>
    /// 裝飾者模式中的具體元件類
    /// </summary>
    public class Apple : Phone
    {
        public override void Do()
        {
            Console.WriteLine("I have got an iPhone.");
        }
    }

    /// <summary>
    /// 裝飾抽象類
    /// </summary>
    public abstract class Decorator : Phone
    {
        private Phone _Phone;
        public Decorator(Phone phone)
        {
            _Phone = phone;
        }
        public override void Do()
        {
            if (_Phone != null)
            {
                _Phone.Do();
            }
        }
    }

    /// <summary>
    /// 開機
    /// </summary>
    public class TurnOnPower : Decorator
    {
        public TurnOnPower(Phone phone) : base(phone)
        {
        }

        public override void Do()
        {
            base.Do();

            // 新增新行為
            Console.WriteLine("開機");
        }
    }

    /// <summary>
    /// 保護貼
    /// </summary>
    public class Sticker : Decorator
    {
        public Sticker(Phone phone) : base(phone)
        {
        }

        public override void Do()
        {
            base.Do();

            // 新增新行為
            Console.WriteLine("貼上保護貼");
        }
    }

    /// <summary>
    /// 手機殼
    /// </summary>
    public class Case : Decorator
    {
        public Case(Phone phone) : base(phone)
        {
        }
        public override void Do()
        {
            base.Do();

            // 新增新行為
            Console.WriteLine("裝上手機殼");
        }
    }
}