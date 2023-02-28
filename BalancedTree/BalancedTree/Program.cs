using System;
using System.Drawing;

namespace BalancedTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            TreeNode root = new TreeNode();
            root = root.Create_Balanced(size);
            Console.WriteLine("Среднее среди корней дерева: "+root.MiddleRootInTree(size));
            Console.WriteLine("Число отрицательных корней в дереве: "+root.CountNegative);
            Console.WriteLine("Число положительных корней в дереве: " + root.CountPositive);
            Console.Write("Введите символ для поиска в корнях дерева:");
            char c = Console.ReadLine().ToCharArray()[0];
            Console.WriteLine("Число корней содержащих "+c+" : " + root.CheckRootInTree(root, c));
        }
    }

    public class TreeNode// Класс «Узел бинарного дерева»
    {
        private char info; // информационное поле
        private TreeNode left; // ссылка на левое поддерево
        private TreeNode right;// ссылка на правое поддерево
        private int countPositive;
        private int countNegative;
        public int CountPositive// для получения числа положительных пользователем
        {
            get { PositiveRootInTree(this); return countPositive; }
            set { }
        }
        public int CountNegative// для получения числа отрицтельных пользователем(отрицательных не может быть ,так как дерево состоит из одного символа)
        {
            get { NegativeRootInTree(this); return countNegative; }
            set { }
        }
        public char Info { get; set; } // свойства
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }
        public TreeNode() { } // конструкторы
        public TreeNode(char info)
        {
            Info = info;
        }
        public TreeNode(char info, TreeNode left, TreeNode right)
        {
            Info = info; Left = left; Right = right;
        }
        public TreeNode Create_Balanced(int n) // n – количество узлов в дереве
        {
            char x;
            TreeNode root; // ссылка на корень дерева и на корень любого из поддеревьев
            if (n == 0)
                root = null; // если n == 0, построить пустое дерево
            else
            { // заполнить информационное поле корня
                Console.WriteLine("введите значение поля узла (символ):");
                x = Char.Parse(Console.ReadLine());
                root = new TreeNode(x); // создать корень дерева
                root.Left = Create_Balanced(n / 2); // построить левое поддерево (*1 *)
                root.Right = Create_Balanced(n - n / 2 - 1); // построить правое поддерево(*2 *)
            }
            return root; //(*3*)
        }
        public void OutTree(TreeNode root, int position)
        {
            if (root != null)
            {
                Console.WriteLine(root.Info);
                OutTree(root.Left, position++);
                OutTree(root.Right, position++);
            }
        }
        public int CheckRootInTree(TreeNode root,char c)
        {
            int count = 0;
            if(root!= null)
            {
                if (root.Info == c) count++;
                count += CheckRootInTree(root.Left, c);
                count += CheckRootInTree(root.Right, c);
            }
            return count;
        }
        public void PositiveRootInTree(TreeNode root)
        {   
            if(root != null)
            {
                if (root.Info-48>0) this.countPositive++;
                PositiveRootInTree(root.Left);
                PositiveRootInTree(root.Right);
            }
        }
        public void NegativeRootInTree(TreeNode root)
        {
            if (root != null)
            {
                if (root.Info - 48 > 0) this.countNegative++;
                NegativeRootInTree(root.Left);
                NegativeRootInTree(root.Right);
            }
        }
        public double SumRootInTree(TreeNode root)
        {
            double result = 0;
            if (root != null)
            {
                result += root.Info - 48;
                result += SumRootInTree(root.Left);
                result += SumRootInTree(root.Right);
            }
            return result;
        }
        public double MiddleRootInTree(int size)
        {
            return Math.Round(SumRootInTree(this)/size,0);  
        }
    }

}
