using System;
using System.Collections;

namespace Behavioral_10_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ArrayList list = new ArrayList();

            context.Sentence = "待解釋的句子。";
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());

            // Interpret

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            Console.ReadLine();
        }

        // 待解譯的語句
        class Context
        {
            public string Sentence { get; set; }

            public string GetContext()
            {
                return Sentence;
            }
        }


        interface AbstractExpression
        {
            /// <summary>
            /// 翻譯
            /// </summary>
            /// <param name="context"></param>
            void Interpret(Context context);
        }

        /// <summary>
        /// 最小規則
        /// </summary>
        class TerminalExpression : AbstractExpression
        {
            public void Interpret(Context context)
            {
                Console.WriteLine("This is Terminal.Interpret()");
            }
        }

        /// <summary>
        /// 可擴展規則，直到最小規則為止
        /// </summary>
        class NonterminalExpression : AbstractExpression
        {
            public void Interpret(Context context)
            {
                Console.WriteLine("This is Nonterminal.Interpret()");
            }
        }
    }
}
