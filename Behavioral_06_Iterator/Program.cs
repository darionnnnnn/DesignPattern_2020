using System;
using System.Collections;

namespace Behavioral_06_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            var concreteAggregate = new ConcreteAggregate();

            for (int j = 0; j < 10; j++)
            {
                concreteAggregate[j] = $"Item {j}";
            }
            
            var iterator = concreteAggregate.CreateIterator();

            Console.WriteLine("遍歷集合 : ");

            while (!iterator.IsLast())
            {
                Console.WriteLine(iterator.CurrentItem());
                iterator.Next();
            }

            Console.WriteLine(iterator.Last());

            iterator.SetCurrent(0);

            Console.WriteLine("遍歷集合 again : ");

            while (!iterator.IsLast())
            {
                Console.WriteLine(iterator.CurrentItem());
                iterator.Next();
            }

            Console.WriteLine(iterator.Last());

            Console.ReadLine();
        }

        class ConcreteAggregate
        {
            private ArrayList _dataList = new ArrayList();

            public Iterator CreateIterator()
            {
                return new ConcreteIterator(this);
            }

            public int Count => _dataList.Count;

            public object this[int index]
            {
                get { return _dataList[index]; }
                set { _dataList.Insert(index, value); }
            }
        }

        interface Iterator
        {
            void SetCurrent(int currentIndex);
            object First();
            object Last();
            object Next();
            bool IsLast();
            object CurrentItem();
        }

        class ConcreteIterator : Iterator
        {
            private ConcreteAggregate _aggregate { get; }
            private int _currentIndex;

            public ConcreteIterator(ConcreteAggregate aggregate)
            {
                _aggregate = aggregate;
            }

            public void SetCurrent(int currentIndex)
            {
                _currentIndex = currentIndex >= _aggregate.Count? _aggregate.Count - 1 : currentIndex;
            }

            public object First()
            {
                return _aggregate[0];
            }

            public object Last()
            {
                return _aggregate[_aggregate.Count - 1];
            }

            public object Next()
            {
                object ret = null;
                if (_currentIndex < _aggregate.Count - 1)
                {
                    ret = _aggregate[++_currentIndex];
                }

                return ret;
            }

            public object CurrentItem()
            {
                return _aggregate[_currentIndex];
            }

            public bool IsLast()
            {
                return _currentIndex >= _aggregate.Count - 1;
            }
        }
    }
}
