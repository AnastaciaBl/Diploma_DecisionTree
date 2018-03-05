using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Data
    {
        public double[] Arguments { get; private set; } // x1, ..., xN
        public double Y { get; private set; } // value of function
        public bool[] IsQualitative { get; private set; }
        public int AmountOfArguments { get; private set; }

        //test
        public Data(double[] args, double y, bool[] Is, int amount)
        {
            Arguments = args;
            Y = y;
            IsQualitative = Is;
            AmountOfArguments = amount;
        }

        public Data(int amountOfArgs)
        {
            AmountOfArguments = amountOfArgs;
            Arguments = new double[AmountOfArguments];
        }

        public Data(string stringData)
        {
            DataFromString(stringData);
        }

        //FOR V.2
        //need to think about missing values
        //create a check-function which define is this data has missing values
        private void DataFromString(string str)
        {
            string[] temp = str.Replace("\t", " ").Split(' ');
            Y = Convert.ToDouble(temp[0]);
            AmountOfArguments = (temp.Length - 1) / 2; // Y (X_1 IsQ) ... (X_N IsQ)
            Arguments = new double[AmountOfArguments]; // first argument is Y, last argument check IsQualitative
            IsQualitative = new bool[AmountOfArguments];
            int counter = 0;
            for (int i = 1; i < temp.Length; i++)
            {
                if(i % 2 != 0)
                    Arguments[counter] = Convert.ToDouble(temp[i]);
                else
                {
                    if (Convert.ToDouble(temp[i]) == 0)
                        IsQualitative[counter] = false;
                    else IsQualitative[counter] = true;
                    counter++;
                }
            }
        }
    }
}
