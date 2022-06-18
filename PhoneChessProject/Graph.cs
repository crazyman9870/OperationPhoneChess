using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public class Graph
    {

        public const int Rows = 4;
        public const int Columns = 3;

        public int combinations { get; private set; }

        private int[,] _graph = new int[Rows, Columns]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { -1, 0, -1 }
        };

        private List<List<ChessNode>> _nodes;

        public Graph(NodeType type)
        {
            _nodes = new List<List<ChessNode>>();

            for (int row = 0; row < Rows; row++)
            {
                _nodes.Add(new List<ChessNode>());
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
                    this._nodes[row].Add(n);

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
                    _nodes[row][col].DiscoverEdges(_nodes, Rows, Columns);
                }
            }
        }

        public void findNumberCombinations()
        {
            int count = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    var node = _nodes[row][col];
                    if (node.Value > 1)
                    {
                        node.TraverseNode(_nodes, "", ref count);
                    }
                }
            }
            combinations = count;
        }
    }
}