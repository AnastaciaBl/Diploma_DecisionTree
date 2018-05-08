using System;
using System.Collections.Generic;
using System.IO;

namespace DecisionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testSample = new List<string>();
            using (StreamReader sr = new StreamReader("test.txt"))
            {
                while (!sr.EndOfStream)
                    testSample.Add(sr.ReadLine());
            }
            DecisionTree dt = new DecisionTree(testSample, 0.1);
            Console.ReadLine();    
        }
    }
}
