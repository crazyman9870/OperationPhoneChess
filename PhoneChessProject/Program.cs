using System;

namespace PhoneChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[4,3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 },
                { -1, 0, -1 }
            };

            Graph g = new Graph(graph, 4, 3);
        }
    }
}
