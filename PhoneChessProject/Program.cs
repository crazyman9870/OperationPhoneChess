using System;

namespace PhoneChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var type = NodeType.Pawn; type <= NodeType.Knight; type++)
            {
                Graph graph = new Graph(type);
                graph.AddEdges();
                graph.findNumberCombinations();
                Console.WriteLine(String.Format("Combinations for {0} = {1}", type, graph.combinations));
            }
            Console.ReadKey();
        }
    }
}
