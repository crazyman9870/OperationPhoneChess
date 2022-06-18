using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public class Graph
    {
        /// <summary>
        /// Defines the maximum boundries of the grid
        /// </summary>
        public const int Rows = 4;
        public const int Columns = 3;

        /// <summary>
        /// Keeps track of all the phone number combinations that are possible
        /// </summary>
        public int combinations { get; private set; }

        /// <summary>
        /// Grid the graph will be based on
        /// </summary>
        private int[,] grid = new int[Rows, Columns]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            { -1, 0, -1 }
        };

        /// <summary>
        /// Graph representation of the grid in ChessNode
        /// </summary>
        private List<List<ChessNode>> _nodesGraph;

        /// <summary>
        /// Contructor
        /// With the defined grid generates the node graph with the appropriate type of ChessNode
        /// </summary>
        /// <param name="type">Type of ChessNode that will be used in the graph</param>
        public Graph(NodeType type)
        {
            _nodesGraph = new List<List<ChessNode>>();

            for (int row = 0; row < Rows; row++)
            {
                _nodesGraph.Add(new List<ChessNode>());
                for (int col = 0; col < Columns; col++)
                {
                    int val = grid[row, col];
                    ChessNode node = null;
                    switch (type)
                    {
                        case NodeType.Pawn:
                            node = new PawnNode(val, row, col);
                            break;
                        case NodeType.Knight:
                            node = new KnightNode(val, row, col);
                            break;
                        case NodeType.Bishop:
                            node = new BishopNode(val, row, col);
                            break;
                        case NodeType.Rook:
                            node = new RookNode(val, row, col);
                            break;
                        case NodeType.Queen:
                            node = new QueenNode(val, row, col);
                            break;
                        case NodeType.King:
                            node = new KingNode(val, row, col);
                            break;
                        default:
                            break;
                    }
                    this._nodesGraph[row].Add(node);
                }
            }
        }

        /// <summary>
        /// Loops though each of the nodes in the graph and sets up the related edges
        /// </summary>
        public void AddEdges()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    _nodesGraph[row][col].DiscoverEdges(_nodesGraph, Rows, Columns);
                }
            }
        }

        /// <summary>
        /// Finds the number of phone nmuber combinations that can be created using the given ChessNode
        /// Skips over values <= 1
        /// Begins recursion on the graph
        /// </summary>
        public void FindNumberCombinations()
        {
            int count = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    var node = _nodesGraph[row][col];
                    if (node.Value > 1)
                    {
                        node.TraverseNode("", ref count);
                    }
                }
            }
            combinations = count;
        }
    }
}