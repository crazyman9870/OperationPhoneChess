using System.Net.NetworkInformation;
using System.Xml.XPath;
using System.Xml;
using System.Threading;
using System;
namespace PhoneChessProject
{
    public const enum NodeType
    {
        Pawn = 0,
        Knight,
        Bishop,
        Rook,
        Queen,
        King
    }

    public interface Node
    {
        //Value of the current node
        string Value { get; set; }

        //List of reachable nodes from this node
        Node[] reachableNodes { get; set; }

        //Add a node to the list
        bool AddReachableNode();
    }
}
