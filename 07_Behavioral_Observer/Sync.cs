using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Behavioral_Observer
{
    public class Sync
    {
        public void Run()
        {
            var subject = new Observable();
            // 註冊觀察者
            subject.Attach(new Observer_A(subject));
            subject.Attach(new Observer_B(subject));

            // 被觀察者內容更新
            subject.NewContent = "ABC";
            // 通知觀察者
            subject.Notify();
        }

        /// <summary>
        /// 被觀察者，實作觀察者模式
        /// </summary>
        class Observable
        {
            private List<IObserver> _observers = new List<IObserver>();

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (IObserver observer in _observers)
                {
                    observer.Update();
                }
            }

            // 更新內容
            public string NewContent { get; set; }
        }

        interface IObserver
        {
            void Update();
        }

        /// <summary>
        /// 觀察者 A
        /// </summary>
        class Observer_A : IObserver
        {
            private Observable Observable { get; }

            public Observer_A(Observable observable)
            {
                Observable = observable;
            }

            public void Update()
            {
                Console.WriteLine($"Observer A, get new content {Observable.NewContent}");
            }
        }

        /// <summary>
        /// 觀察者 B
        /// </summary>
        class Observer_B : IObserver
        {
            private Observable Observable { get; }

            public Observer_B(Observable observable)
            {
                Observable = observable;
            }

            public void Update()
            {
                Console.WriteLine($"Observer B, get new content {Observable.NewContent}");
            }
        }
    }
}
