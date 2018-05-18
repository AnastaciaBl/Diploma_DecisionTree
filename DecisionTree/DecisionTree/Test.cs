using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Test
    {
        public Data[] trainingSample { get; private set; }
        public Data[] testSample { get; private set; }
        private const double percentageOfSampleForTest = 0.2;

        public Test(Data[] allElements)
        {
            int amountOfElementInTestSample = (int)Math.Round(allElements.Length * percentageOfSampleForTest);
            testSample = new Data[amountOfElementInTestSample];
            trainingSample = new Data[allElements.Length - amountOfElementInTestSample];
            for (int i = 0; i < amountOfElementInTestSample; i++)
                testSample[i] = allElements[i];
            for (int i = amountOfElementInTestSample; i < allElements.Length; i++)
                trainingSample[i - amountOfElementInTestSample] = allElements[i];
        }
    }
}
