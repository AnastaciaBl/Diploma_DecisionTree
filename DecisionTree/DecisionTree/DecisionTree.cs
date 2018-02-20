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
            Data[] left = new Data[(int)node.Rule[2]];
            Data[] right = new Data[node.AmountOfElements - (int)node.Rule[2]];
            ReturnPartOfElements(left, right, node.Elements);
            node.IsBigger = CheckSide(left, right);
            node.LeftChild = new DecisionTreeNode(left);
            node.RightChild = new DecisionTreeNode(right);
        }

        private bool CheckSide(Data[] left, Data[] right) //extra information about Rule (> or <=)
        {
            int amount = right.GetLength(0) / 10;
            if (amount == 0)
                amount = right.GetLength(0) / 2;
            if (amount == 0)
                amount = 1;
            double counter = 0;
            //!!! correct work only with one argument
            for (int i=0;i<amount;i++)
            {
                if (left[left.Length - 1].Arguments[0] < right[i].Arguments[0])
                    counter++;
            }
            if (counter / amount > 0.5)
                return true;
            else
                return false;
        }

        private int ChooseArgument(Data[] elements)
        {
            //choose argument which separated elements with the smallest error
            return 0;
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

        private double CountError(Data[] elements)
        {
            double error = 0, answer = 0;
            for(int i=0;i<elements.Length;i++)
            {
                error += elements[i].Y;
            }
            error = error / elements.GetLength(0); //average of elements
            for(int i = 0; i < elements.Length; i++) //find RSS sum of (Y_i - error)^2
            {
                answer += Math.Pow((elements[i].Y - error), 2);
            }
            return answer / elements.Length;
        }

        private double[] FindDefiningArgument(Data[] elements)
        {
            //to find the best splitting (with the smallest squares error`s difference)
            //we should check all splittings
            //then we find the argument which define this splitting
            List<double> errorList = new List<double>();
            for(int i=0;i<elements.Length-1;i++)
            {
                double error = 0;
                Data[] tempFirst = new Data[i + 1];
                Data[] tempSecond = new Data[elements.Length - i - 1];
                ReturnPartOfElements(tempFirst, tempSecond, elements);
                error += CountError(tempFirst);
                error += CountError(tempSecond);
                errorList.Add(error);
            }
            int index = FindIndexOfMinErrorSplitting(errorList);
            //[0] - index of argument; [1] - argument
            //!!! correct work only with one argument
            return new double[3] { 1, ((elements[index].Arguments[0] + elements[index+1].Arguments[0]) / 2),
                index + 1 };
        }

        //to split array on two parts
        private void ReturnPartOfElements(Data[] elementsFirst, Data[] elementsSecond, Data[] elements)
        {
            int index = elements.Length - elementsSecond.Length;
            for(int i=0;i<elementsFirst.Length; i++)
            {
                elementsFirst[i] = new Data(elements[i].AmountOfArguments);
                for (int j = 0; j < elements[i].AmountOfArguments; j++)
                    elementsFirst[i].Arguments[j] = elements[i].Arguments[j];
            }
            for(int i=elements.Length - 1;i>=index;i--)
            {
                elementsSecond[i - index] = new Data(elements[i].AmountOfArguments);
                for (int j = 0; j < elements[i].AmountOfArguments; j++)
                    elementsSecond[i-index].Arguments[j] = elements[i].Arguments[j];
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
