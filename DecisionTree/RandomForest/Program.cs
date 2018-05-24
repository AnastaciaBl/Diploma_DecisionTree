using System;
using System.Collections.Generic;
using System.IO;
using DecisionTree;

namespace RandomForest
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
            RandomForest rf = new RandomForest(testSample, 100, 0.1);
            Console.WriteLine($"Answer: {rf.Decide(30.38)}");
            Console.ReadLine();
        }
    }
}
