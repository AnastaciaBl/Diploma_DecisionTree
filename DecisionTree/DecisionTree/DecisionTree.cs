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
        public int AmountOfArguments { get; set; }

        public DecisionTree(List<string> trainingSampleLines)
        {
            double[,] trainingSample = CreateTrainingSample(trainingSampleLines);
            AmountOfArguments = trainingSample.GetLength(1)-1;
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
                if (CountError(tempNode.Elements) != 0)
                {
                    tempNode.Rule = FindDefiningArgument(tempNode.Elements);
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
            double[,] left = new double[(int)node.Rule[2], node.Elements.GetLength(1)];
            double[,] right = new double[node.AmountOfElements - (int)node.Rule[2], node.Elements.GetLength(1)];
            ReturnPartOfElements(left, right, node.Elements);
            node.LeftChild = new DecisionTreeNode(left);
            node.RightChild = new DecisionTreeNode(right);
        }

        private void CutUselessNodes()
        {
            //improve the tree
            //cut leaves which doesn`t have a lot of influence on result
        }

        private double[,] CreateTrainingSample(List<string> args)
        {
            args[0] = args[0].Replace("\t", " ");
            string[] amountOfArguments = args[0].Split(' ');
            double[,] trainingSample = new double[args.Count - 1, amountOfArguments.Length];
            for (int i = 1; i < args.Count; i++) //args[0] = "y x1 x2 ... xN"
            {
                args[i] = args[i].Replace("\t", " ");
                string[] temp = args[i].Split(' ');
                trainingSample[i - 1, 0] = Convert.ToDouble(temp[0]);
                for (int j = 1; j < temp.Length; j++)
                    trainingSample[i - 1, j] = Convert.ToDouble(temp[j]);
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
            while(qe.Count != 0)
            {
                DecisionTreeNode tempNode = new DecisionTreeNode();
                tempNode = qe.Dequeue();
                if(tempNode.IsLeaf == true)
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

        private double CountError(double[,] elements)
        {
            double error = 0, answer = 0;
            for(int i=0;i<elements.GetLength(0);i++)
            {
                error += elements[i, 0];
            }
            error = error / elements.GetLength(0); //average of elements
            for(int i = 0; i < elements.GetLength(0); i++) //find RSS sum of (Y_i - error)^2
            {
                answer += Math.Pow((elements[i, 0] - error), 2); //elements[i, 0] -> Y, elements[i, 1..n] -> X
            }
            return answer / elements.GetLength(0);
        }

        private double[] FindDefiningArgument(double[,] elements)
        {
            //to find the best splitting (with the smallest squares error`s difference)
            //we should check all splittings
            //then we find the argument which define this splitting
            List<double> errorList = new List<double>();
            for(int i=0;i<elements.GetLength(0)-1;i++)
            {
                double error = 0;
                double[,] tempFirst = new double[i + 1, elements.GetLength(1)];
                double[,] tempSecond = new double[elements.GetLength(0) - i - 1, elements.GetLength(1)];
                ReturnPartOfElements(tempFirst, tempSecond, elements);
                error += CountError(tempFirst);
                error += CountError(tempSecond);
                errorList.Add(error);
            }
            int index = FindIndexOfMinErrorSplitting(errorList);
            //[0] - index of argument; [1] - argument
            //!!! correct work only with one argument
            return new double[3] { 1, ((elements[index,1] + elements[index + 1,1]) / 2), index + 1 };
        }

        //to split array on two parts
        private void ReturnPartOfElements(double[,] elementsFirst, double[,] elementsSecond, double[,] elements)
        {
            int index = elements.GetLength(0) - elementsSecond.GetLength(0);
            for(int i=0;i<elementsFirst.GetLength(0);i++)
            {
                for (int j = 0; j < elementsFirst.GetLength(1); j++)
                    elementsFirst[i, j] = elements[i, j];
            }
            for(int i=elements.GetLength(0)-1;i>=index;i--)
            {
                for (int j = 0; j < elementsSecond.GetLength(1); j++)
                    elementsSecond[i-index, j] = elements[i, j];
            }
        }

        private int FindIndexOfMinErrorSplitting(List<double> errors)
        {
            int index = -1;
            double min = 10000;
            for (int i=0;i<errors.Count;i++)
            {
                if(errors[i]<min)
                {
                    min = errors[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
