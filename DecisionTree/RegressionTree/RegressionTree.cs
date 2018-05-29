using System;
using System.Collections.Generic;

namespace DecisionTree
{
    public class RegressionTree
    {
        public DecisionTreeNode Head { get; set; }
        public string Name { get; set; }
        public double TreeError { get; private set; }
        public double Penalty { get; private set; }

        private RegressionTree() { }

        public RegressionTree(Test trainingSample, double penalty)
        {
            Head = new DecisionTreeNode(trainingSample.TrainingSample);
            Head.IsHead = true;
            Penalty = penalty;
            Learn();
            CutUselessNodes(trainingSample.TestSample);
        }

        public RegressionTree(Test trainingSample, string name, double penalty) :this(trainingSample, penalty)
        {
            Name = name;
        }

        public RegressionTree(RegressionTree dt)
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

        public double Deside(params double[] x)
        {
            //give an answer
            DecisionTreeNode tempNode = findLeafWithAnswer(x);
            double answer = countFinalAverageAnswer(tempNode);
            return answer;
        }

        private DecisionTreeNode findLeafWithAnswer(params double[] x)
        {
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(Head);
            DecisionTreeNode tempNode = new DecisionTreeNode();
            tempNode = qe.Dequeue();
            while (!tempNode.IsLeaf)
            {
                if (tempNode.Rule.IsQualitative)
                {
                    if (tempNode.Rule.Rules.Contains(x[tempNode.Rule.IndexOfArgument]))
                        qe.Enqueue(tempNode.RightChild);
                    else
                        qe.Enqueue(tempNode.LeftChild);
                }
                else
                {
                    if (x[tempNode.Rule.IndexOfArgument] > tempNode.Rule.Rules[0])
                        qe.Enqueue(tempNode.RightChild);
                    else
                        qe.Enqueue(tempNode.LeftChild);
                }
                tempNode = qe.Dequeue();
            }
            return tempNode;
        }

        private double countFinalAverageAnswer(DecisionTreeNode node)
        {
            double answer = 0;
            for(int i=0;i<node.Elements.Length;i++)
            {
                answer += node.Elements[i].Y;
            }
            answer = answer / node.Elements.Length;
            return answer;
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

        private void CutUselessNodes(Data[] testSample)
        {
            //improve the tree
            //cut leaves which doesn`t have a lot of influence on result
            PostPruningAlgorithm algorithm = new PostPruningAlgorithm(this, Penalty, testSample);
            Head = algorithm.TheBestTree.Head;
        }

        private DecisionTreeNode DeepCopy(RegressionTree copyTree)
        {
            RegressionTree newDecisionTree = new RegressionTree();
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

        public double TestDataSet(Data[] data)
        {
            double error = 0;
            for(int i=0;i<data.Length;i++)
            {
                double tempError = Math.Abs(this.Deside(data[i].Arguments) - data[i].Y);
                error = tempError * tempError;
            }
            error = Math.Sqrt(error);
            return error;
        }
    }
}
