using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneChessProject
{
    class Program
    {
        /// <summary>
        /// Main entry point
        /// Loops though all different chess peices types
        /// Contructs a graph of the grid into the appropriate type of chess nodes
        /// Adds reachable edges to each of the chess nodes
        /// Finds all possible phone number combinations
        /// Prints results to screen and outputs them to a file in the pojrect/bin
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string docPath = Directory.GetParent(workingDirectory).Parent.FullName;
            List<string> outputText = new List<string>();

            for (var type = NodeType.Pawn; type <= NodeType.King; type++)
            {
                Graph graph = new Graph(type);
                graph.AddEdges();
                graph.FindNumberCombinations();
                string line = String.Format("Combinations for {0} = {1}", type, graph.combinations);
                Console.WriteLine(line);
                outputText.Add(line);
            }

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ChessNodeCombinations.txt")))
            {
                foreach (string line in outputText)
                {
                    outputFile.WriteLine(line);
                }
            }
        }
    }
}
