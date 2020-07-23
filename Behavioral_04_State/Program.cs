using System;

namespace Behavioral_05_State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context(new ConcreteStateA());

            c.Request();
            c.Request();
            c.Request();
            c.Request();

            Console.ReadLine();
        }

        abstract class State
        {
            public abstract void Handle(Context context);
        }

        class ConcreteStateA : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateB();
            }
        }

        class ConcreteStateB : State
        {
            public override void Handle(Context context)
            {
                context.State = new ConcreteStateA();
            }
        }

        class Context
        {
            private State _state;

            public Context(State state)
            {
                State = state;
            }

            public State State
            {
                get => _state;
                set
                {
                    _state = value;
                    Console.WriteLine("State: " + _state.GetType().Name);
                }
            }

            public void Request()
            {
                _state.Handle(this);
            }
        }
    }
}
