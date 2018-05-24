using System;
using System.Collections.Generic;
using DecisionTree;

namespace RandomForest
{
    public class RandomForest
    {
        private List<RegressionTree> trees { get; set; }
        private Test trainingSample { get; set; }
        public int AmountOfTrees { get; private set; }
        public double Penalty { get; private set; }

        public RandomForest(Data[] dataSample, int amountOfTrees, double penalty)
        {
            trees = new List<RegressionTree>();
            AmountOfTrees = amountOfTrees;
            Penalty = penalty;
            trainingSample = new Test(dataSample);
            createForest();
        }

        private void createForest()
        {
            Random random = new Random();
            for (int i=0;i<AmountOfTrees;i++)
            {
                string name = $"Tree #{i + 1}";
                bool flag = false;
                //on some data sets RegressionTree.dll doesn`t create a rule and then make an exception
                while (!flag)
                    try
                    {
                        Test testSample = createRandomDataSample(random);
                        trees.Add(createTree(name, testSample));
                        flag = true;
                    }
                    catch { }
            }
        }

        private Test createRandomDataSample(Random random)
        {
            var newTrainingSample = new Data[trainingSample.TrainingSample.Length];
            for (int i = 0; i < newTrainingSample.Length; i++)
            {
                int randomIndex = random.Next(0, newTrainingSample.Length);
                newTrainingSample[i] = trainingSample.TrainingSample[randomIndex];
            }
            var testSample = new Test(newTrainingSample, trainingSample.TestSample);
            return testSample;
        }

        private RegressionTree createTree(string name, Test testSample)
        {
            RegressionTree tree = new RegressionTree(testSample, name, Penalty);
            return tree;
        }

        public double Decide(params double[] X)
        {
            double answer = 0;
            for(int i=0;i<AmountOfTrees;i++)
            {
                answer += trees[i].Deside(X);
            }
            answer = answer / AmountOfTrees;
            return answer;
        }
    }
}
