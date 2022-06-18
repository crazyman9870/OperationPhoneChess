using System.Security.AccessControl;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public class PawnNode : ChessNode
    {
        public PawnNode(int value, int row, int column) : base(value, row, column)
        {
            this.multiDirection = false;
            this.diagonal = false;
        }

        public override bool AddReachableNode()
        {
            return true;
        }

        public override void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount)
        {
            if (IsValidNode(Row, Column - 1, rowCount, colCount))
            {
                reachableNodes.Add(nodeGraph[Row][Column - 1]);
            }
            
            if (IsValidNode(Row - 1, Column, rowCount, colCount))
            {
                reachableNodes.Add(nodeGraph[Row - 1][Column]);
            }

            if (IsValidNode(Row, Column + 1, rowCount, colCount))
            {
                reachableNodes.Add(nodeGraph[Row][Column + 1]);
            }
            
             if (IsValidNode(Row + 1, Column, rowCount, colCount))
            {
                reachableNodes.Add(nodeGraph[Row + 1][Column]);
            }
        }
    }
}