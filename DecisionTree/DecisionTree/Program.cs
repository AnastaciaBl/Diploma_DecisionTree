using System;
using System.Collections.Generic;
using System.IO;

namespace DecisionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testSampleLines = new List<string>();
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                while (!sr.EndOfStream)
                    testSampleLines.Add(sr.ReadLine());
            }
            Data[] testSample = Data.CreateDataSample(testSampleLines);
            Test learningSample = new Test(testSample);
            Test newTest = createRandomDataSample(learningSample, new Random());
            RegressionTree dt = new RegressionTree(learningSample, 0.1);
            Console.WriteLine(dt.Deside(30.38));
            Console.ReadLine();    
        }

        private static Test createRandomDataSample(Test trainingSample, Random random)
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
    }
}
