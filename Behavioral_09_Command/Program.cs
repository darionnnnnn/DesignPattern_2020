using System;

namespace Behavioral_09_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();

            // step 1 將命令接收者傳入命令中
            Command command = new ConcreteCommand(receiver);
            
            Invoker invoker = new Invoker();

            // step 2 將命令傳入呼叫者中
            invoker.SetCommand(command);

            // step 3 經由呼叫者中 ExecuteCommand 方法執行實作命令中 Execute 方法，再由 Execute 方法執行接收者中 Action 方法
            //        Invoker.ExecuteCommand() → ConcreteCommand.Execute() → Receiver.Action()
            invoker.ExecuteCommand();

            Console.ReadLine();
        }

        /// <summary>
        /// 抽象命令
        /// 於建構子中注入接收者
        /// </summary>
        abstract class Command
        {
            protected readonly Receiver _Receiver;

            protected Command(Receiver receiver)
            {
                _Receiver = receiver;
            }

            public abstract void Execute();
        }

        /// <summary>
        /// 實作命令
        /// </summary>
        class ConcreteCommand : Command
        {
            public ConcreteCommand(Receiver receiver) :
                base(receiver)
            {
            }

            /// <summary>
            /// 執行
            /// </summary>
            public override void Execute()
            {
                _Receiver.Action();
            }
        }

        /// <summary>
        /// 接收命令者
        /// </summary>
        class Receiver
        {
            public void Action()
            {
                Console.WriteLine("This is _Receiver.Action()");
            }
        }

        /// <summary>
        /// 呼叫者
        /// </summary>
        class Invoker
        {
            private Command _command;

            /// <summary>
            /// 設定命令
            /// </summary>
            /// <param name="command"></param>
            public void SetCommand(Command command)
            {
                _command = command;
            }

            /// <summary>
            /// 執行命令
            /// </summary>
            public void ExecuteCommand()
            {
                _command.Execute();
            }
        }
    }
}
