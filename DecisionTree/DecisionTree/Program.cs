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
            RegressionTree dt = new RegressionTree(testSample, 0.1);
            Console.WriteLine(dt.Deside(30.38));
            Console.ReadLine();    
        }
    }
}
