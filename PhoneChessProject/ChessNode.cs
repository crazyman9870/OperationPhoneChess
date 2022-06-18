using System.Net.NetworkInformation;
using System.Xml.XPath;
using System.Xml;
using System.Threading;
using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public enum NodeType
    {
        Pawn = 0,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public abstract class ChessNode
    {
        //Value of the current node
        public int Value { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        //List of reachable nodes from this node
        public List<ChessNode> reachableNodes { get; set; }

        public bool multiDirection { get; set; }

        public bool diagonal { get; set; }

        public ChessNode(int value, int row, int column)
        {
            this.Value = value;
            this.Row = row;
            this.Column = column;
            reachableNodes = new List<ChessNode>();
        }

        //Add a node to the list
        public abstract bool AddReachableNode();

        /// <summary>
        /// Function to find reachable edges from this node within the grid.
        /// Given the number of rows and columns in the grid ChessNodes can determine which other nodes are reachable
        /// </summary>
        /// <param name="nodeGraph">The current node graph</param>
        /// <param name="rowCount">Number of rows in the grid</param>
        /// <param name="colCount">Number of columns in the grid</param>
        public abstract void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount);

        /// <summary>
        /// Given a current row and column, determines if it falls within the bounds of rowCount and columnCount of the grid
        /// </summary>
        /// <param name="row">Row coordinates</param>
        /// <param name="col">Column coordinates</param>
        /// <param name="rowCount">Grid row count</param>
        /// <param name="colCount">Grid column count</param>
        /// <returns>true if the coordinates exist in the grid, otherwise false</returns>
        protected bool IsValidNode(int row, int col, int rowCount, int colCount)
        {
            if (row >= 0 && row < rowCount && col >= 0 && col < colCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
