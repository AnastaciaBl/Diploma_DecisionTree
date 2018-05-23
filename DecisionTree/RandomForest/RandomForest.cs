using System;
using System.Collections.Generic;
using DecisionTree;

namespace RandomForest
{
    class RandomForest
    {
        private List<RegressionTree> trees { get; set; }
        private Test trainingSample { get; set; }
        public int AmountOfTrees { get; private set; }

        public RandomForest(Data[] dataSample, int amountOfTrees)
        {
            AmountOfTrees = amountOfTrees;
            trainingSample = new Test(dataSample);
        }

        private Data[] createRandomDataSample()
        {
            var dataSample = new Data[trainingSample.TrainingSample.Length];
            return dataSample;
        }
    }
}
