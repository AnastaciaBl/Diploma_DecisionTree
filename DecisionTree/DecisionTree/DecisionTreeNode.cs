using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class DecisionTreeNode
    { 
        public DecisionTreeNode RightChild { get; set; } //the rule was executed (>)
        public DecisionTreeNode LeftChild { get; set; } //the rule wasn`t executed (<=)
        public int AmountOfElements { get; private set; }//how much elements this node has inside
        public Rule Rule { get; set; }
        public Data[] Elements { get; set; }
        public bool IsLeaf
        {
            get {
                if (RightChild == null && LeftChild == null)
                    return true;
                else
                    return false;
            }
        }

        public DecisionTreeNode() { }

        public DecisionTreeNode(Data[] elements)
        {
            Elements = elements;
            AmountOfElements = Elements.Length;
        }

        private bool Compute(double[] rule)
        {
            //compute which side has a new child: left or right
            return true;
        }
    }
}
