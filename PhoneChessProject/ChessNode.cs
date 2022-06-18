using System.Collections.Generic;

namespace PhoneChessProject
{
    /// <summary>
    /// Enumeration of the different types of chess pieces
    /// </summary>
    public enum NodeType
    {
        Pawn = 0,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    /// <summary>
    /// Enumeration of different directions a piece can move
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        UpRight,
        UpLeft,
        DownRight,
        DownLeft
    }

    /// <summary>
    /// Abstract class definition of chess nodes
    /// </summary>
    public abstract class ChessNode
    {
        /// <summary>
        /// Value of the node
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Row the current node resides on
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Column the current node resides in
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// List of reachable nodes from this node
        /// </summary>
        public List<ChessNode> ReachableNodes { get; set; }

        /// <summary>
        /// Base contrutctor for children to use
        /// </summary>
        /// <param name="value">value of the node</param>
        /// <param name="row">row the node is on</param>
        /// <param name="column">column the node is in</param>
        public ChessNode(int value, int row, int column)
        {
            this.Value = value;
            this.Row = row;
            this.Column = column;
            ReachableNodes = new List<ChessNode>();
        }

        /// <summary>
        /// Function to find reachable edges from this node within the grid.
        /// Given the number of rows and columns in the grid ChessNodes can determine which other nodes are reachable
        /// </summary>
        /// <param name="nodeGraph">The current node graph</param>
        /// <param name="rowCount">Number of rows in the grid</param>
        /// <param name="colCount">Number of columns in the grid</param>
        public abstract void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount);

        /// <summary>
        /// Recursively visits all reachable nodes from the current node
        /// Stops when the depth of the recursive traversal reaches 7
        /// </summary>
        /// <param name="currentValue">string represenation of the phone number</param>
        /// <param name="count">current combination count</param>
        public virtual void TraverseNode(string currentValue, ref int count)
        {
            if (this.Value < 0)
            {
                return;
            }

            currentValue += this.Value;
            if (currentValue.Length == 7)
            {
                count++;
                return;
            }

            foreach (var node in ReachableNodes)
            {
                node.TraverseNode(currentValue, ref count);
            }
        }

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
