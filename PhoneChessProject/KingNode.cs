using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneChessProject
{
    public class KingNode : ChessNode
    {
        /// <summary>
        /// KingNode constructor
        /// </summary>
        /// <param name="value">value of the node</param>
        /// <param name="row">row the node is on</param>
        /// <param name="column">column the node is in</param>
        public KingNode(int value, int row, int column) : base(value, row, column)
        {

        }

        /// <summary>
        /// Adds edges to KingNode
        /// Kings can move in any direction by 1 space
        /// </summary>
        /// <param name="nodeGraph">graph of nodes to add the edge to the list</param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
        public override void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount)
        {
            //Up
            if (IsValidNode(Row - 1, Column, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 1][Column]);
            }
            //Down
            if (IsValidNode(Row + 1, Column, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 1][Column]);
            }
            //Left
            if (IsValidNode(Row, Column - 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row][Column - 1]);
            }
            //Right
            if (IsValidNode(Row, Column + 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row][Column + 1]);
            }

            //Up left
            if (IsValidNode(Row - 1, Column - 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 1][Column - 1]);
            }
            //Up right
            if (IsValidNode(Row - 1, Column + 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row - 1][Column + 1]);
            }
            //Down right
            if (IsValidNode(Row + 1, Column + 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 1][Column + 1]);
            }
            //Down left
            if (IsValidNode(Row + 1, Column - 1, rowCount, colCount))
            {
                ReachableNodes.Add(nodeGraph[Row + 1][Column - 1]);
            }


        }
    }
}
