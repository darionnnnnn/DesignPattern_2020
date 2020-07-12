using System;
using System.Collections.Generic;

namespace _06_Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            // 建立樹狀結構
            Branch root = new Branch("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            Branch branch_X = new Branch("Branch X");
            branch_X.Add(new Leaf("Leaf X_A"));
            branch_X.Add(new Leaf("Leaf X_B"));
            root.Add(branch_X);

            Leaf leaf_C = new Leaf("Leaf C");
            root.Add(leaf_C);
            
            Branch branch_X_Y = new Branch("Branch X_Y");
            branch_X_Y.Add(new Leaf("Leaf X_Y_A"));
            branch_X_Y.Add(new Leaf("Leaf X_Y_B"));
            branch_X.Add(branch_X_Y);

            root.Add(new Leaf("Leaf D"));
            root.Add(new Leaf("Leaf E"));

            // 刪除節點
            root.Remove(leaf_C);

            // 印出當前樹狀結構
            root.Print(0);

            Console.ReadLine();
        }

        /// <summary>
        /// 父類別 > 樹
        /// </summary>
        abstract class Tree
        {
            protected string _NodeName;

            public Tree(string nodeName)
            {
                _NodeName = nodeName;
            }

            public abstract void Add(Tree tree);
            public abstract void Remove(Tree tree);
            public abstract void Print(int depth);
        }

        /// <summary>
        /// 子類別 > 分支
        /// </summary>
        class Branch : Tree
        {
            private List<Tree> _children = new List<Tree>();

            public Branch(string nodeName)
                : base(nodeName)
            {
            }

            public override void Add(Tree tree)
            {
                _children.Add(tree);
            }

            public override void Remove(Tree tree)
            {
                _children.Remove(tree);
            }

            public override void Print(int depth)
            {
                Console.WriteLine(new string('-', depth) + _NodeName);

                // Recursively display child nodes

                foreach (Tree component in _children)
                {
                    component.Print(depth + 2);
                }
            }
        }

        /// <summary>
        /// 子類別 > 葉
        /// </summary>
        class Leaf : Tree
        {
            public Leaf(string nodeName)
                : base(nodeName)
            {
            }

            public override void Add(Tree c)
            {
                Console.WriteLine("Leaf can't add child node.");
            }

            public override void Remove(Tree c)
            {
                Console.WriteLine("Leaf have no child node.");
            }

            public override void Print(int depth)
            {
                Console.WriteLine(new string('-', depth) + _NodeName);
            }
        }
    }
}