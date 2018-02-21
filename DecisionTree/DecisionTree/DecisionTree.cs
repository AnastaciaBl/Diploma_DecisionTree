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
        public string Name { get; set; }

        public DecisionTree(List<string> trainingSampleLines)
        {
            Data[] trainingSample = CreateTrainingSample(trainingSampleLines);
            Head = new DecisionTreeNode(trainingSample);
            Learn();
        }

        public DecisionTree(List<string> trainingSampleLines, string name):this(trainingSampleLines)
        {
            Name = name;
        }

        private void Learn()
        {
            //build the tree using CART algorithm
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(Head);
            while (GeneralMethods.ErrorSum(Head) > 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (GeneralMethods.CountError(tempNode.Elements) != 0)
                {
                    tempNode.Rule = new Rule(tempNode.Elements);
                    AddChildren(tempNode);
                    qe.Enqueue(tempNode.LeftChild);
                    qe.Enqueue(tempNode.RightChild);
                }
            }
        }

        public void Deside()
        {
            //give an answer
        }

        private void AddChildren(DecisionTreeNode node) //add new nodes to the tree
        {
            //Rule[0] - index of argument; Rule[1] - average argument value; Rule[2] - amount elements of LeftChild
            Data[] left = null, right = null;
            if(node.Rule.IsQualitative)
            {

            }
            else
            {
                node.Rule.DivideSampleByNotQualitiveRule(out left, out right, node.Elements, 
                    node.Rule.Rules[0], node.Rule.IndexOfArgument);
            }
            node.LeftChild = new DecisionTreeNode(left);
            node.RightChild = new DecisionTreeNode(right);
        }

        private void CutUselessNodes()
        {
            //improve the tree
            //cut leaves which doesn`t have a lot of influence on result
        }

        private Data[] CreateTrainingSample(List<string> args)
        {
            Data[] trainingSample = new Data[args.Count-1];
            for (int i = 1; i < args.Count; i++) //args[0] = "y x1 x2 ... xN"
            {
                trainingSample[i-1] = new Data(args[i]);
            }
            return trainingSample;
        }
    }
}
