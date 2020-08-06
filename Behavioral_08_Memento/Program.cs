using System;

namespace Behavioral_08_Memento
{
    class Program
    {
        /// <summary>
        /// 以備份方式實作復原功能
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // step 1 創建物件
            var originator = new Originator
                             {
                                 State = "On"
                             };
            // step 2 備份
            var caretaker = new Caretaker
                            {
                                Memento = originator.CreateMemento()
                            };
            // step 3 修改物件狀態
            originator.State = "Off";
            // step 4 還原
            originator.SetMemento(caretaker.Memento);

            Console.ReadLine();
        }

        /// <summary>
        /// 被保留內部狀態的物件
        /// </summary>
        class Originator
        {
            private string _state;

            public string State
            {
                set
                {
                    _state = value;
                    Console.WriteLine("State: " + _state);
                }
            }

            public Memento CreateMemento()
            {
                return (new Memento(_state));
            }

            public void SetMemento(Memento memento)
            {
                Console.WriteLine("Restore state.");
                State = memento.State;
            }
        }

        /// <summary>
        /// 保留 Originator 內部狀態 (資料) 的物件
        /// </summary>
        class Memento
        {
            public string State { get; }

            public Memento(string state)
            {
                State = state;
            }
        }

        /// <summary>
        /// 管理 Memento
        /// </summary>
        class Caretaker
        {
            public Memento Memento { set; get; }
        }
    }
}
