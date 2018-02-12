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
        public bool IsLeaf { get; set; }
        public int AmountOfElements { get; set; }//how much elements this node has inside
        private double[] Rule { get; set; } //[0] - index of argument; [1] - index of element`s position

        public DecisionTreeNode()
        {
            Rule = new double[2];
        }

        private bool Compute(double rule)
        {
            //compute which side has a new child: left or right
            return true;
        }

        private double[] FindDefiningArgument()
        {
            //find argument which has the smallest squares error`s difference 
            return new double[2];
        }
    }
}
