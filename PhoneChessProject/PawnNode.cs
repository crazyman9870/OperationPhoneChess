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
        public PawnNode(int value, int row, int column) : base(value)
        {
            this.Row = row;
            this.Column = column;
            this.multiDirection = false;
            this.diagonal = false;
        }

        public override bool AddReachableNode()
        {
            return true;
        }

        public override List<int[]> GetPossibleMoves()
        {
            return null;
        }
    }
}