using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree
{
    class Rule
    {
        public double Error { get; set; }
        public List<double> Rules { get; set; }
        public int IndexOfArgument { get; set; }
        public bool IsQualitative { get; set; }

        private Rule()
        {
            Rules = new List<double>();
        }

        public Rule(Data[] elements):this()
        {
            Rule temp = ChooseRule(elements);
            Error = temp.Error;
            Rules = temp.Rules;
            IndexOfArgument = temp.IndexOfArgument;
            IsQualitative = temp.IsQualitative;
        }

        private Rule ChooseRule(Data[] elements)
        {
            //choose argument which separated elements with the smallest error
            List<Rule> rulesQualitative = new List<Rule>();
            List<Rule> rulesNotQualitive = new List<Rule>();
            for (int i = 0; i < elements[0].AmountOfArguments; i++)
            {
                switch (elements[0].IsQualitative[i])
                {
                    case true:
                        break;
                    case false:
                        rulesNotQualitive =
                            rulesNotQualitive.Concat(CreateRulesForNotQualitativeArguments(elements, i)).ToList();
                        break;
                }
            }
            return FindRuleWithTheSmallestError(rulesQualitative.Concat(rulesNotQualitive).ToList());
        }

        private List<Rule> CreateRulesForNotQualitativeArguments(Data[] elements, int indexOfArgument)
        {
            List<Rule> rules = new List<Rule>();
            double[] valuesOfArgument = SortValuesOfArgument(elements, indexOfArgument);
            for (int j = 0; j < valuesOfArgument.Length; j++)
            {
                Rule temp = new Rule();
                temp.IndexOfArgument = indexOfArgument;
                temp.IsQualitative = false;
                if (j + 1 < valuesOfArgument.Length)
                    temp.Rules.Add(CreateValueForRule(valuesOfArgument, j));
                else
                    temp.Rules.Add(valuesOfArgument[j]);
                Data[] left = null, right = null;
                DivideSampleByNotQualitiveRule(out left, out right, elements, temp.Rules[0], indexOfArgument);
                temp.Error = GeneralMethods.CountError(left);
                temp.Error += GeneralMethods.CountError(right);
                rules.Add(temp);
            }
            return rules;
        }

        private double[] SortValuesOfArgument(Data[] elements, int indexOfArgument)
        {
            double[] temp = new double[elements.Length];
            for (int i = 0; i < elements.Length; i++)
                temp[i] = elements[i].Arguments[indexOfArgument];
            Array.Sort(temp);
            return temp;
        }

        private double CreateValueForRule(double[] values, int index)
        {
            return (values[index] + values[index + 1]) / 2;
        }

        public void DivideSampleByNotQualitiveRule(out Data[] leftSample, out Data[] rightSample,
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

        private Rule FindRuleWithTheSmallestError(List<Rule> rules)
        {
            double minError = 10000;
            Rule temp = new Rule();
            for (int i = 0; i < rules.Count; i++)
            {
                if (rules[i].Error < minError)
                {
                    minError = rules[i].Error;
                    temp = rules[i];
                }
            }
            return temp;
        }
    }
}
