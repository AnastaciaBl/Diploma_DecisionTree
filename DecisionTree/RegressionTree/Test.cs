using System;

namespace DecisionTree
{
    public class Test
    {
        public Data[] TrainingSample { get; private set; }
        public Data[] TestSample { get; private set; }
        public const int AmountOfParts = 5;
        public int WhichPartWillBeTheNext { get; private set; }

        private const double PercentageOfSampleForTest = 0.2;
        private Data[] allElements { get; set; }

        public Test(Data[] _allElements)
        {
            allElements = _allElements;
            WhichPartWillBeTheNext = 0;
            int amountOfElementInTestSample = (int)Math.Round(allElements.Length * PercentageOfSampleForTest);
            TestSample = new Data[amountOfElementInTestSample];
            TrainingSample = new Data[allElements.Length - amountOfElementInTestSample];
            SplitDataOnTestAndTrainParts();
        }

        public void SplitDataOnTestAndTrainParts()
        {
            if (WhichPartWillBeTheNext != AmountOfParts)
            {
                int testIndex = 0, trainIndex = 0;
                for (int i = 0; i < WhichPartWillBeTheNext * TestSample.Length; i++)
                {
                    TrainingSample[i] = allElements[i];
                    trainIndex++;
                }
                for (int i = WhichPartWillBeTheNext * TestSample.Length;
                    i < WhichPartWillBeTheNext * TestSample.Length + TestSample.Length; i++)
                {
                    TestSample[testIndex] = allElements[i];
                    testIndex++;
                }
                for (int i = WhichPartWillBeTheNext * TestSample.Length + TestSample.Length; i < allElements.Length; i++)
                {
                    TrainingSample[trainIndex] = allElements[i];
                    trainIndex++;
                }
                WhichPartWillBeTheNext++;
            }
        }
    }
}
