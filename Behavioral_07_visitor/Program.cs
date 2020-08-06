using System;
using System.Collections.Generic;

namespace Behavioral_07_visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectStructure = new ObjectStructure();
            objectStructure.Attach(new ConcreteElementA());
            objectStructure.Attach(new ConcreteElementB());

            var concreteVisitor1 = new ConcreteVisitor1();
            //var concreteVisitor2 = new ConcreteVisitor2();

            // Structure accepting visitors

            objectStructure.Accept(concreteVisitor1);
            //objectStructure.Accept(concreteVisitor2);

            Console.ReadLine();
        }

        class ObjectStructure
        {
            private List<Element> _elements = new List<Element>();

            public void Attach(Element element)
            {
                _elements.Add(element);
            }

            public void Detach(Element element)
            {
                _elements.Remove(element);
            }

            public void Accept(Visitor visitor)
            {
                foreach (var element in _elements)
                {
                    element.Accept(visitor);
                }
            }
        }

        interface Element
        {
            void Accept(Visitor visitor);
        }

        class ConcreteElementA : Element
        {
            public void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementA(this);
            }
        }

        class ConcreteElementB : Element
        {
            public void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementB(this);
            }
        }

        interface Visitor
        {
            void VisitConcreteElementA(ConcreteElementA concreteElementA);
            void VisitConcreteElementB(ConcreteElementB concreteElementB);
        }

        class ConcreteVisitor1 : Visitor
        {
            public void VisitConcreteElementA(ConcreteElementA concreteElementA)
            {
                Console.WriteLine($"{concreteElementA.GetType().Name} visited by {GetType().Name}");
            }

            public void VisitConcreteElementB(ConcreteElementB concreteElementB)
            {
                Console.WriteLine($"{concreteElementB.GetType().Name} visited by {GetType().Name}");
            }
        }

        class ConcreteVisitor2 : Visitor
        {
            public void VisitConcreteElementA(ConcreteElementA concreteElementA)
            {
                Console.WriteLine($"{concreteElementA.GetType().Name} visited by {GetType().Name}");
            }

            public void VisitConcreteElementB(ConcreteElementB concreteElementB)
            {
                Console.WriteLine($"{concreteElementB.GetType().Name} visited by {GetType().Name}");
            }
        }
    }
}
