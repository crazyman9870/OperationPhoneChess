using System.Net.NetworkInformation;
using System.Xml.XPath;
using System.Xml;
using System.Threading;
using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public enum NodeType
    {
        Pawn = 0,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public abstract class ChessNode
    {
        //Value of the current node
        public int Value { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        //List of reachable nodes from this node
        public List<ChessNode> reachableNodes { get; set; }

        public bool multiDirection { get; set; }

        public bool diagonal { get; set; }

        public ChessNode(int value)
        {
            this.Value = value;
            reachableNodes = new List<ChessNode>();
        }

        //Add a node to the list
        public abstract bool AddReachableNode();

        //Gets node's possible edges
        public abstract List<int[]> GetPossibleMoves();
    }
}
