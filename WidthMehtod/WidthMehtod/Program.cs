using System;
using System.Collections.Generic;
using System.Linq;

namespace WidthMehtod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[,] smezhnosti =
            {
                {false,true,true,false,false},
                {false,false,false,true,false},
                {false,true,false,false,true},
                {false,false,true,false,false},
                {false,false,false,true,false}
            };
            int[,] weigths =
            {
                {0,4,8,0,0},
                {0,0,0,6,0},
                {0,2,0,0,4},
                {0,0,10,0,0},
                {0,0,0,4,0}
            };
            Graph gr = new Graph(5,smezhnosti,weigths);
            List<int> ls = new List<int>();
            int exit_dot = 3;
            for (int i = 0; i < gr.Size; i++)
            {
                if (gr.Adjacency[0,i] && i == exit_dot)
                {
                    ls.Add(weigths[0,i]);
                }
                else if (gr.Adjacency[0, i])
                {
                    ls.Add(gr.Weight(i, exit_dot, weigths[0, i]));
                }
               // if(ls.Count != 0)Console.WriteLine(ls.Min());
            }
            Console.WriteLine(ls.Min());
           
        }
    }
    public class Graph
    {
        private int[,] weights;
        private int[] result;
        public int Size { get; set; }
        public bool[,] Adjacency { get; set; }
        public bool[] Vector { get; set; }

        public Graph(int size, bool[,] G, int[,] w)
        {
            Adjacency = new bool[size, size];
            Adjacency = G;
            weights = w;
            Vector = new bool[size];
            for (int i = 0; i < size; i++)
                Vector[i] = false;
            Size = size;
            result = new int[size];
        }
        public void Depth(int i)
        {
            Vector[i] = true;
            Console.Write("{0}" + ' ', i);
            for (int k = 0; k < Size; k++)
                if (Adjacency[i, k] && !(Vector[k]))
                    Depth(k); 
        }
        public int Weight(int i,int d,int weight)
        {
            for (int k = 0; k < Size; k++)
            {
                if (Adjacency[i, k] && k == d) 
                    return weight += weights[i, k];
                else if (Adjacency[i, k])
                {
                    weight += weights[i,k];
                    
                    Weight(k, d, weight);
                }
                    
            }
            return int.MaxValue;
        }
    }
}
