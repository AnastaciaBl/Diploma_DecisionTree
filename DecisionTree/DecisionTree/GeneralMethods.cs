using System;
using System.Collections.Generic;

namespace DecisionTree
{
    static class GeneralMethods
    {
        public static double CountError(Data[] elements)
        {
            double error = 0, answer = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                error += elements[i].Y;
            }
            error = error / elements.Length; //average of elements
            for (int i = 0; i < elements.Length; i++) //find RSS sum of (Y_i - error)^2
            {
                answer += Math.Pow((elements[i].Y - error), 2);
            }
            return answer / elements.Length;
        }

        public static void DivideSampleByQualitiveRule(out Data[] leftSample, out Data[] rightSample,
                                            Data[] elements, List<double> rule, int argumentIndex)
        {
            List<Data> left = new List<Data>();
            List<Data> right = new List<Data>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (rule.Contains(elements[i].Arguments[argumentIndex]))
                    right.Add(elements[i]);
                else
                    left.Add(elements[i]);
            }
            leftSample = left.ToArray();
            rightSample = right.ToArray();
        }

        public static void DivideSampleByNotQualitiveRule(out Data[] leftSample, out Data[] rightSample,
                                                    Data[] elements, double rule, int argumentIndex)
        {
            List<Data> left = new List<Data>();
            List<Data> right = new List<Data>();
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i].Arguments[argumentIndex] > rule)
                    right.Add(elements[i]);
                else
                    left.Add(elements[i]);
            }
            leftSample = left.ToArray();
            rightSample = right.ToArray();
        }
    }
}
