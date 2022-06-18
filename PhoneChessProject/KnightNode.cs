using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneChessProject
{
    public class KnightNode : ChessNode
    {
        public KnightNode(int value, int row, int column) : base(value, row, column)
        {
            this.MultiDirection = false;
            this.Diagonal = false;
        }

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

        public override void TraverseNode(List<List<ChessNode>> nodeGraph, string currentValue, ref int count)
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
                node.TraverseNode(nodeGraph, currentValue, ref count);
            }
        }
    }
}
