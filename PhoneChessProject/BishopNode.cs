using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneChessProject
{
    public class BishopNode : ChessNode
    {

        public BishopNode(int value, int row, int column) : base(value, row, column)
        {
            this.MultiDirection = false;
            this.Diagonal = true;
        }
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
