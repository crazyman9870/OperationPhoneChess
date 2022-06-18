using System;

namespace PhoneChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var type = NodeType.Pawn; type <= NodeType.Pawn; type++)
            {
                Console.WriteLine(type);
                Graph g = new Graph(type);
                g.AddEdges();
                g.findNumberCombinations();
                Console.WriteLine(String.Format("Combinations for {0} = {1}", nameof(type), g.combinations));
            }
            Console.ReadKey();
        }
    }
}
