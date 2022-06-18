using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneChessProject
{
    public class QueenNode : ChessNode
    {
        /// <summary>
        /// QueenNode constructor
        /// </summary>
        /// <param name="value">value of the node</param>
        /// <param name="row">row the node is on</param>
        /// <param name="column">column the node is in</param>
        public QueenNode(int value, int row, int column) : base(value, row, column)
        {

        }

        /// <summary>
        /// Adds edges to QueenNode
        /// Queens can move in any direction any number of spaces
        /// </summary>
        /// <param name="nodeGraph">graph of nodes to add the edge to the list</param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        public override void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount)
        {
            for (int i = 1; i < rowCount; i++)
            {
                //Up
                if (IsValidNode(Row - i, Column, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row - i][Column]);
                }
                //Down
                if (IsValidNode(Row + i, Column, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row + i][Column]);
                }
            }

            for (int i = 1; i < colCount; i++)
            {
                //Left
                if (IsValidNode(Row, Column - i, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row][Column - i]);
                }
                //Right
                if (IsValidNode(Row, Column + i, rowCount, colCount))
                {
                    ReachableNodes.Add(nodeGraph[Row][Column + i]);
                }
            }

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
