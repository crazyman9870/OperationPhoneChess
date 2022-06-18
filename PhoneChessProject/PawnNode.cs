using System.Collections.Generic;

namespace PhoneChessProject
{
    public class PawnNode : ChessNode
    {
        /// <summary>
        /// Dictionary of the ChessNodes that are edges for the pawn node.
        /// Each edge needs an associated direction because once a pawn is moving in a direction it can only continue in that same direction
        /// </summary>
        Dictionary<Direction, ChessNode> directionalNodes;

        /// <summary>
        /// PawnNode constructor
        /// Initializes the diretionalNodes datastructure
        /// </summary>
        /// <param name="value">value of the node</param>
        /// <param name="row">row the node is on</param>
        /// <param name="column">column the node is in</param>
        public PawnNode(int value, int row, int column) : base(value, row, column)
        {
            directionalNodes = new Dictionary<Direction, ChessNode>();
        }

        /// <summary>
        /// Adds edges to PawnNode
        /// Pawns can move in any horizontal/vertical direction by 1 space
        /// </summary>
        /// <param name="nodeGraph">graph of nodes to add the edge to the list</param>
        /// <param name="rowCount"></param>
        /// <param name="colCount"></param>
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

        /// <summary>
        /// PawnNodes are unique since they can only move in one direction
        /// Overrides parent functionality to call a new recursive function that will preserve the traversals direction
        /// </summary>
        /// <param name="currentValue">string represenation of the phone number</param>
        /// <param name="count">current combination count</param>
        public override void TraverseNode(string currentValue, ref int count)
        {
            if (this.Value < 0)
            {
                return;
            }

            currentValue = this.Value.ToString();

            foreach(var item in directionalNodes)
            {
                PawnNode node = (PawnNode)item.Value;
                node.recTraverseNode(currentValue, ref count, item.Key);
            }
        }

        /// <summary>
        /// Recursive function to traverse the path of the PawnNode while maintaining direction
        /// /// Stops when the depth of the recursive traversal reaches 7
        /// </summary>
        /// <param name="currentValue">string represenation of the phone number</param>
        /// <param name="count">current combination count</param>
        /// <param name="direction">direction to grab correct reachable node</param>
        private void recTraverseNode(string currentValue, ref int count, Direction direction)
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
                node.recTraverseNode(currentValue, ref count, direction);
            }
        }
    }
}