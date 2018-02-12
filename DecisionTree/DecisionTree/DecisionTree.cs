using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class DecisionTree
    {
        public DecisionTreeNode Head { get; set; }

        public DecisionTree(List<string> trainingSampleLines)
        {

        }

        private void Learn(List<double> args)
        {
            //build the tree using CART algorithm
        }

        public void Deside()
        {
            //give an answer
        }

        private void AddNode()
        {
            //add a new node
        }

        private void CutUselessNodes()
        {
            //improve the tree
            //cut leaves which doesn`t have a lot of influence on result
        }
    }
}
