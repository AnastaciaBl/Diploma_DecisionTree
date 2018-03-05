using System.Collections.Generic;

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
            while (ErrorSum() > 0)
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
            Data[] left = null, right = null;
            if(node.Rule.IsQualitative)
            {
                GeneralMethods.DivideSampleByQualitiveRule(out left, out right, node.Elements,
                    node.Rule.Rules, node.Rule.IndexOfArgument);
            }
            else
            {
                GeneralMethods.DivideSampleByNotQualitiveRule(out left, out right, node.Elements, 
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

        private double ErrorSum()
        {
            //traversing the tree in breadth
            //if the node is a leaf, count an error
            double answer = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(Head);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (tempNode.IsLeaf == true)
                {
                    answer += GeneralMethods.CountError(tempNode.Elements);
                }
                if (tempNode.LeftChild != null)
                    qe.Enqueue(tempNode.LeftChild);
                if (tempNode.RightChild != null)
                    qe.Enqueue(tempNode.RightChild);
            }
            return answer;
        }
    }
}
