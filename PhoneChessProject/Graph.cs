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

        public List<ChessNode> nodes;

        public Graph(NodeType type)
        {
            nodes = new List<ChessNode>();

            for (int row = 0; row < Rows; row++)
            {
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

                    n.GetPossibleMoves();
                    this.nodes.Add(n);

                    Console.WriteLine(val.ToString());

                    this.addEdgesToNodes(n);
                }
            }
        }

        private void addEdgesToNodes(ChessNode n)
        {
            int row = n.Row;
            int col = n.Column;

            Console.WriteLine(currentMoves.Length);
        }

        private bool isValidNode()
        {
            return false;
        }

    }
}