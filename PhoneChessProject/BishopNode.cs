using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneChessProject
{
    public class BishopNode : ChessNode
    {
        /// <summary>
        /// BishopNode constructor
        /// </summary>
        /// <param name="value">value of the node</param>
        /// <param name="row">row the node is on</param>
        /// <param name="column">column the node is in</param>
        public BishopNode(int value, int row, int column) : base(value, row, column)
        {

        }

        /// <summary>
        /// Adds edges to BishopNode
        /// Bishops can move in any direction diagonally
        /// </summary>
        /// <param name="nodeGraph">graph of nodes to add the edge to the list</param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        public override void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount)
        {
            for (int i = 1; i < Math.Min(rowCount, colCount); i++)
            {
                //Up left
                if (IsValidNode(Row - i, Column - i, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row - i][Column - i]);
                }
                //Up right
                if (IsValidNode(Row - i, Column + i, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row - i][Column + i]);
                }
                //Down right
                if (IsValidNode(Row + i, Column + i, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row + i][Column + i]);
                }
                //Down left
                if (IsValidNode(Row + i, Column - i, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row + i][Column - i]);
                }
            }
        }
    }
}
