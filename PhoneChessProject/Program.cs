using System;

namespace PhoneChessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var type = NodeType.Pawn; type <= NodeType.King; type++)
            {
                Console.WriteLine(type);
                Graph g = new Graph(type);
                
            }
            Console.ReadKey();
        }
    }
}
