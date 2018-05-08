using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class PostPruningAlgorithm
    {
        private int amountOfElementsInDataSet;
        private List<DecisionTree> trees;
        private List<double> valueOfTree;
        private double penalty;
        public DecisionTree TheBestTree;

        public PostPruningAlgorithm(DecisionTree startTree, double penaltyForComplicatedTree)
        {
            amountOfElementsInDataSet = startTree.Head.AmountOfElements;
            trees = new List<DecisionTree>();
            valueOfTree = new List<double>();
            penalty = penaltyForComplicatedTree;
            trees.Add(startTree);
            valueOfTree.Add(findValueOfTree(startTree));
            TheBestTree = cutUselessNodes();
        }

        private DecisionTree cutUselessNodes()
        {
            List<double> values = findValuesOfNodes(trees[0]);
            int amountOfTrees = values.Count;
            for (int i=1;i< amountOfTrees; i++)
            {
                double min = values.Min();
                int index = values.FindIndex(m => m.Equals(min));
                trees.Add(createNewTree(trees[i-1], index));
                values.RemoveAt(index);
            }
            int indexOfTheBestTree = findIndexOfTheBestTree(trees);
            return trees[indexOfTheBestTree];
        }

        private int findIndexOfTheBestTree(List<DecisionTree> trees)
        {
            int indexOfTheBestTree = -1;
            List<double> values = new List<double>();
            for (int i = 0; i < trees.Count; i++)
                values.Add(findValueOfTree(trees[i]));
            double min = values.Min();
            for(int i = 0; i < values.Count; i++)
            {
                if (values[i] == min && indexOfTheBestTree == -1)
                    indexOfTheBestTree = i;
                else if(values[i] == min && indexOfTheBestTree != -1)
                {
                    if (findAmountOfLeaves(trees[i].Head) < findAmountOfLeaves(trees[indexOfTheBestTree].Head))
                        indexOfTheBestTree = i;
                }
            }
            return indexOfTheBestTree;
        }
        
        private double findValueOfTree(DecisionTree tree)
        {
            double value = -1;
            value = findErrorSumOfLeaves(tree.Head) + penalty * findAmountOfLeaves(tree.Head);
            return value;
        }

        private List<double> findValuesOfNodes(DecisionTree tree)
        {
            List<double> values = new List<double>();
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(tree.Head);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (!tempNode.IsLeaf)
                {
                    values.Add(findInfluenseOfNode(tempNode));
                    qe.Enqueue(tempNode.LeftChild);
                    qe.Enqueue(tempNode.RightChild);
                }
            }
            return values;
        }

        private double findInfluenseOfNode(DecisionTreeNode node)
        {
            int amountOfLeaves = findAmountOfLeaves(node);
            double sumLeavesError = findErrorSumOfLeaves(node);
            double value = (Rule.FindErrorInNode(node.Elements, amountOfElementsInDataSet) - sumLeavesError)/
                (amountOfLeaves - 1);
            return value;
        }

        private double findErrorSumOfLeaves(DecisionTreeNode node)
        {
            double error = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(node);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (tempNode.IsLeaf)
                {
                    error += Rule.FindErrorInNode(tempNode.Elements, amountOfElementsInDataSet);
                }
                else
                {
                    qe.Enqueue(tempNode.LeftChild);
                    qe.Enqueue(tempNode.RightChild);
                }
            }
            return error;
        }

        private int findAmountOfLeaves(DecisionTreeNode node)
        {
            int amountOfLeaves = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(node);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (tempNode.IsLeaf)
                {
                    amountOfLeaves++;
                }
                else
                {
                    qe.Enqueue(tempNode.LeftChild);
                    qe.Enqueue(tempNode.RightChild);
                }
            }
            return amountOfLeaves;
        }

        private DecisionTree createNewTree(DecisionTree tree, int positionOfExtraNode)
        {
            DecisionTree newDt = new DecisionTree(tree);
            int counter = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(newDt.Head);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (tempNode.IsLeaf) { }
                else if (positionOfExtraNode == counter)
                {
                    tempNode.LeftChild = null;
                    tempNode.RightChild = null;
                    tempNode.Rule = null;
                    break;
                }
                else if (!tempNode.IsLeaf)
                {
                    qe.Enqueue(tempNode.LeftChild);
                    qe.Enqueue(tempNode.RightChild);
                    counter++;
                }
            }
            return newDt;
        }
    }
}
