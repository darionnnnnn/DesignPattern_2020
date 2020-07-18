using System;
using System.Threading;
using System.Threading.Tasks;

namespace _08_Behavioral_Template
{
    public class Callback
    {
        public void Run()
        {
            Console.WriteLine($"Method Run，執行緒ID: {Thread.CurrentThread.ManagedThreadId}");

            Async_Callback asyncCallback = new Async_Callback();
            
            asyncCallback.OnCompletion += (sender, eventArgs) =>
                                          {
                                              Console.WriteLine("---");
                                              Console.WriteLine($"callback 開始，執行緒ID: {Thread.CurrentThread.ManagedThreadId}");
                                              Console.WriteLine("callback 結束");
                                              Console.WriteLine("---");
                                          };
            
            Console.WriteLine($"DoSomething 開始，執行緒ID: {Thread.CurrentThread.ManagedThreadId}");
            
            asyncCallback.DoSomething();

            Console.WriteLine($"DoSomething 結束，執行緒ID: {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadLine();
        }

        public class Async_Callback
        {
            public EventHandler OnCompletion;
            public void DoSomething()
            {
                Console.WriteLine($"DoSomething，執行緒ID: {Thread.CurrentThread.ManagedThreadId}");
                Task.Run(() =>
                         {
                             Console.WriteLine($"new Task 呼叫 callback，執行緒ID: {Thread.CurrentThread.ManagedThreadId}");
                             OnCompletion?.Invoke(this, EventArgs.Empty);
                         }).Wait();
            }
        }
    }

    
}