using System.Collections.Generic;

namespace PhoneChessProject
{
    public class PawnNode : ChessNode
    {
        Dictionary<Direction, ChessNode> directionalNodes;

        public PawnNode(int value, int row, int column) : base(value, row, column)
        {
            this.MultiDirection = false;
            this.Diagonal = false;

            this.directionalNodes = new Dictionary<Direction, ChessNode>();
        }

        public override void DiscoverEdges(List<List<ChessNode>> nodeGraph, int rowCount, int colCount)
        {
            if (IsValidNode(Row, Column - 1, rowCount, colCount))
            {
                directionalNodes.Add(Direction.Left, nodeGraph[Row][Column - 1]);
            }
            
            if (IsValidNode(Row - 1, Column, rowCount, colCount))
            {
                directionalNodes.Add(Direction.Up, nodeGraph[Row - 1][Column]);
            }

            if (IsValidNode(Row, Column + 1, rowCount, colCount))
            {
                directionalNodes.Add(Direction.Right, nodeGraph[Row][Column + 1]);
            }
            
            if (IsValidNode(Row + 1, Column, rowCount, colCount))
            {
                directionalNodes.Add(Direction.Down, nodeGraph[Row + 1][Column]);
            }
        }

        public override void TraverseNode(List<List<ChessNode>> nodeGraph, string currentValue, ref int count)
        {
            if (this.Value < 0)
            {
                return;
            }

            currentValue = this.Value.ToString();

            foreach(var item in directionalNodes)
            {
                PawnNode node = (PawnNode)item.Value;
                node.recTraverseNode(nodeGraph, currentValue, ref count, item.Key);
            }
        }

        private void recTraverseNode(List<List<ChessNode>> nodeGraph, string currentValue, ref int count, Direction direction)
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

            if (directionalNodes.ContainsKey(direction))
            {
                var node = (PawnNode)directionalNodes[direction];
                node.recTraverseNode(nodeGraph, currentValue, ref count, direction);
            }
        }
    }
}