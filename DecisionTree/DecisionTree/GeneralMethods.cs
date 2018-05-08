using System;
using System.Collections.Generic;

namespace DecisionTree
{
    static class GeneralMethods
    {
        public static double FindErrorSum(DecisionTree tree)
        {
            //traversing the tree in breadth
            //if the node is a leaf, count an error
            double answer = 0;
            Queue<DecisionTreeNode> qe = new Queue<DecisionTreeNode>();
            qe.Enqueue(tree.Head);
            while (qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if (tempNode.IsLeaf == true)
                {
                    answer += CountError(tempNode.Elements);
                }
                if (tempNode.LeftChild != null)
                    qe.Enqueue(tempNode.LeftChild);
                if (tempNode.RightChild != null)
                    qe.Enqueue(tempNode.RightChild);
            }
            return answer;
        }

        public static double CountError(Data[] elements)
        {
            double error = 0, answer = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                error += elements[i].Y;
            }
            error = error / elements.Length; //average of elements
            for (int i = 0; i < elements.Length; i++) //find RSS sum of (Y_i - error)^2
            {
                answer += Math.Pow((elements[i].Y - error), 2);
            }
            return answer / elements.Length;
        }

        public static void DivideSampleByQualitiveRule(out Data[] leftSample, out Data[] rightSample,
                                            Data[] elements, List<double> rule, int argumentIndex)
        {
            List<Data> left = new List<Data>();
            List<Data> right = new List<Data>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (rule.Contains(elements[i].Arguments[argumentIndex]))
                    right.Add(elements[i]);
                else
                    left.Add(elements[i]);
            }
            leftSample = left.ToArray();
            rightSample = right.ToArray();
        }

        public static void DivideSampleByNotQualitiveRule(out Data[] leftSample, out Data[] rightSample,
                                                    Data[] elements, double rule, int argumentIndex)
        {
            List<Data> left = new List<Data>();
            List<Data> right = new List<Data>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Arguments[argumentIndex] > rule)
                    right.Add(elements[i]);
                else
                    left.Add(elements[i]);
            }
            leftSample = left.ToArray();
            rightSample = right.ToArray();
        }
    }
}
