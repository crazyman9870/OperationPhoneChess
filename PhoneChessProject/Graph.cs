using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public class Graph
    {

        public const int Rows = 4;
        public const int Columns = 3;

        private int[,] _graph = new int[Rows, Columns]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { -1, 0, -1 }
        };

        public List<List<ChessNode>> nodes;

        public Graph(NodeType type)
        {
            nodes = new List<List<ChessNode>>();

            for (int row = 0; row < Rows; row++)
            {
                nodes.Add(new List<ChessNode>());
                for (int col = 0; col < Columns; col++)
                {
                    int val = _graph[row, col];
                    ChessNode n = null;
                    switch (type)
                    {
                        case NodeType.Pawn:
                            n = new PawnNode(val, row, col);
                            break;
                        case NodeType.Knight:
                            break;
                        case NodeType.Bishop:
                            break;
                        case NodeType.Rook:
                            break;
                        case NodeType.Queen:
                            break;
                        case NodeType.King:
                            break;
                        default:
                            break;
                    }
                    this.nodes[row].Add(n);

                    Console.WriteLine(val.ToString());
                }
            }
        }


        public void AddEdges()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    nodes[row][col].DiscoverEdges(nodes, Rows, Columns);
                }
            }
        }

        public void findNumberCombinations()
        {

        }
    }
}