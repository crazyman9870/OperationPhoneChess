using System.Security.AccessControl;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections.Generic;

namespace PhoneChessProject
{
    public class PawnNode : Node
    {

        //Value of the current node
        public int Value { get; set; }

        //List of reachable nodes from this node
        public List<Node> reachableNodes { get; set; }

        public PawnNode() : base()
        {
            this.Value = 1;
            reachableNodes = new List<Node>();            
        }

        public bool AddReachableNode()
        { 
            return true;
        }

    }
}