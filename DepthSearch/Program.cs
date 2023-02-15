using System;
using System.Text;

namespace DepthSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            bool temp = true;
            bool[,] smezhnosti =
            {
                {false,true,true,false,false},
                {false,false,false,true,false},
                {false,true,false,false,true},
                {false,false,true,false,false},
                {false,false,false,true,false}
            };
            Graph gr = new Graph(size,smezhnosti);
            gr.Depth(3);
            for (int i = 0; i < size; i++)
            {
                if (!gr.Vector[i])
                {
                    Console.WriteLine("Граф не связанный!");
                    temp = false;
                    break;
                }     
            }
            if (temp) Console.WriteLine("Граф связанный!");
        }
    }
    public class Graph
    {
        private int size; 
        private bool[,] adjacency;
        private bool[] vector; 
        public int Size { get; set; }
        public bool[,] Adjacency { get; set; }
        public bool[] Vector { get; set; }
      
        public Graph(int size, bool[,] G) 
        {
            Adjacency = new bool[size, size]; 
            Adjacency = G;
            Vector = new bool[size];
            for (int i = 0; i < size; i++)
                Vector[i] = false; 
            Size = size;
        }
        public void Depth(int i) 
        {
            Vector[i] = true; 
            Console.Write("{0}" + ' ', i); 
            for (int k = 0; k < Size; k++) 
                if (Adjacency[i, k] && !(Vector[k]))
                Depth(k); // перейти к обработке вершины k
        }
    }
}
