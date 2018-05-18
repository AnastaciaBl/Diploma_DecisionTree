using System.Collections.Generic;

namespace DecisionTree
{
    class DecisionTree
    {
        public DecisionTreeNode Head { get; set; }
        public string Name { get; set; }
        public double TreeError { get; private set; }
        public double Penalty { get; private set; }

        private DecisionTree() { }

        public DecisionTree(List<string> trainingSampleLines, double penalty)
        {
            Data[] sample = CreateDataSample(trainingSampleLines);
            Test test = new Test(sample);
            Head = new DecisionTreeNode(test.trainingSample);
            Head.IsHead = true;
            Penalty = penalty;
            Learn();
            CutUselessNodes();
        }

        public DecisionTree(List<string> trainingSampleLines, string name, double penalty) :this(trainingSampleLines, penalty)
        {
            Name = name;
        }

        public DecisionTree(DecisionTree dt)
        {
            TreeError = dt.TreeError;
            Penalty = dt.Penalty;
            Name = dt.Name;
            Head = DeepCopy(dt);
        }

        private void Learn()
        {
            //build the tree using CART algorithm
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(Head);
            while (GeneralMethods.FindErrorSum(this) > 0)
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
            TreeError = GeneralMethods.FindErrorSum(this);
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
            node.LeftChild = new DecisionTreeNode(left, true);
            node.RightChild = new DecisionTreeNode(right, false);
        }

        private void CutUselessNodes()
        {
            //improve the tree
            //cut leaves which doesn`t have a lot of influence on result
            PostPruningAlgorithm algorithm = new PostPruningAlgorithm(this, Penalty);
            Head = algorithm.TheBestTree.Head;
        }

        private Data[] CreateDataSample(List<string> args)
        {
            Data[] trainingSample = new Data[args.Count-1];
            for (int i = 1; i < args.Count; i++) //args[0] = "y x1 x2 ... xN"
            {
                trainingSample[i-1] = new Data(args[i]);
            }
            return trainingSample;
        }

        private DecisionTreeNode DeepCopy(DecisionTree copyTree)
        {
            DecisionTree newDecisionTree = new DecisionTree();
            newDecisionTree.Head = new DecisionTreeNode(copyTree.Head);
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(copyTree.Head);
            while (qe.Count != 0)
            {
                int positionOfNode = -1;
                DecisionTreeNode tempNode = qe.Dequeue();
                if (tempNode != copyTree.Head)
                {
                    positionOfNode = getPositionOfActiveNode(copyTree.Head, tempNode, tempNode.IsLeft);
                    copyNode(positionOfNode, newDecisionTree.Head, tempNode, tempNode.IsLeft);
                }
                if (tempNode.LeftChild != null) qe.Enqueue(tempNode.LeftChild);
                if (tempNode.LeftChild != null) qe.Enqueue(tempNode.RightChild);
            }
            return newDecisionTree.Head;
        }

        //проходи по дереву и выясняем каокму "по счету" узлу будем присваивать "детей" при копировании
        private int getPositionOfActiveNode(DecisionTreeNode head, DecisionTreeNode node, bool isLeft)
        {
            int index = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(head);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = qe.Dequeue();
                if (isLeft)
                {
                    if (tempNode.LeftChild == node)
                        break;
                }
                else
                {
                    if (tempNode.RightChild == node)
                        break;
                }
                if (tempNode.LeftChild != null)
                    qe.Enqueue(tempNode.LeftChild);
                if (tempNode.RightChild != null)
                    qe.Enqueue(tempNode.RightChild);
                index++;
            }
            return index;
        }

        private void copyNode(int position, DecisionTreeNode head, DecisionTreeNode node, bool isLeft)
        {
            int currentPosition = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(head);
            while (true)
            {
                DecisionTreeNode tempNode = qe.Dequeue();
                if (currentPosition == position)
                {
                    if (isLeft)
                    {
                        tempNode.LeftChild = new DecisionTreeNode(node);
                        break;
                    }
                    else
                    {
                        tempNode.RightChild = new DecisionTreeNode(node);
                        break;
                    }
                }
                else
                {
                    if (tempNode.LeftChild != null)
                        qe.Enqueue(tempNode.LeftChild);
                    if (tempNode.RightChild != null)
                        qe.Enqueue(tempNode.RightChild);
                }
                currentPosition++;
            }
        }
    }
}
