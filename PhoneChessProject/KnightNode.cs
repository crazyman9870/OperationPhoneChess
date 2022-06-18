using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneChessProject
{
    public class KnightNode : ChessNode
    {
        /// <summary>
        /// KnightNode constructor
        /// </summary>
        /// <param name="value">value of the node</param>
        /// <param name="row">row the node is on</param>
        /// <param name="column">column the node is in</param>
        public KnightNode(int value, int row, int column) : base(value, row, column)
        {

        }

        /// <summary>
        /// Adds edges to KnightNode
        /// Knights can move in any combination of two horizontal moves with one vertical move or two vertical moves with one horizontal move
        /// </summary>
        /// <param name="nodeGraph">graph of nodes to add the edge to the list</param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        public override void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount)
        {
            //Left up
            if (IsValidNode(Row - 1, Column - 2, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 1][Column - 2]);
            }
            //Up left
            if (IsValidNode(Row - 2, Column - 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 2][Column - 1]);
            }
            //Up right
            if (IsValidNode(Row - 2, Column + 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 2][Column + 1]);
            }
            //Right up
            if (IsValidNode(Row - 1, Column + 2, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 1][Column + 2]);
            }
            //Right down
            if (IsValidNode(Row + 1, Column + 2, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 1][Column + 2]);
            }
            //Down right
            if (IsValidNode(Row + 2, Column + 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 2][Column + 1]);
            }
            //Down left
            if (IsValidNode(Row + 2, Column - 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 2][Column - 1]);
            }
            //Left down
            if (IsValidNode(Row + 1, Column - 2, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 1][Column - 2]);
            }
        }
    }
}
