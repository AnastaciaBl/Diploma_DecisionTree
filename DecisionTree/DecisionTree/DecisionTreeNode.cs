using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class DecisionTreeNode
    { 
        public DecisionTreeNode RightChild { get; set; } //the rule was executed
        public DecisionTreeNode LeftChild { get; set; } //the rule wasn`t executed
        public int AmountOfElements { get; private set; }//how much elements this node has inside
        public double[] Rule { get; set; } //[0] - index of argument; [1] - average argument value; 
                                           //[2] - amount elements of LeftChild
        public double[,] Elements { get; set; }
        public bool IsLeaf
        {
            get {
                if (RightChild == null && LeftChild == null)
                    return true;
                else
                    return false;
            }
        }

        public DecisionTreeNode()
        {
            Rule = new double[3];
        }

        public DecisionTreeNode(double[,] elements):this()
        {
            Elements = elements;
            AmountOfElements = Elements.GetLength(0);
        }

        private bool Compute(double[] rule)
        {
            //compute which side has a new child: left or right
            return true;
        }
    }
}
