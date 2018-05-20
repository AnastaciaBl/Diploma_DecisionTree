﻿using System;
using System.Collections.Generic;
using System.IO;

namespace DecisionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> testSample = new List<string>();
            using (StreamReader sr = new StreamReader("test2.txt"))
            {
                while (!sr.EndOfStream)
                    testSample.Add(sr.ReadLine());
            }
            RegressionTree dt = new RegressionTree(testSample, 0.1);
            Console.WriteLine(dt.Deside(30.38));
            Console.ReadLine();    
        }
    }
}
