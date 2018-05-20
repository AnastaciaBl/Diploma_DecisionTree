using System;
using System.Collections.Generic;
using System.Linq;

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

        public Rule(Rule rule):this()
        {
            Error = rule.Error;
            for (int i = 0; i < rule.Rules.Count; i++)
                Rules.Add(rule.Rules[i]);
            IndexOfArgument = rule.IndexOfArgument;
            IsQualitative = rule.IsQualitative;
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
                        rulesQualitative =
                            rulesQualitative.Concat(CreateRulesForQualitativeArguments(elements, i)).ToList();
                        break;
                    case false:
                        rulesNotQualitive =
                            rulesNotQualitive.Concat(CreateRulesForNotQualitativeArguments(elements, i)).ToList();
                        break;
                }
            }
            return FindRuleWithTheSmallestError(rulesQualitative.Concat(rulesNotQualitive).ToList());
        }

        private List<Rule> CreateRulesForQualitativeArguments(Data[] elements, int indexOfArgument)
        {
            List<Rule> rules = new List<Rule>();
            List<double> classes = new List<double>();
            for(int i=0;i<elements.Length;i++)
            {
                if (!classes.Contains(elements[i].Arguments[indexOfArgument]))
                    classes.Add(elements[i].Arguments[indexOfArgument]);
            }
            classes.Sort();
            rules = GetPowerSetOfRules(classes, indexOfArgument);
            CountErrorInQualitativeRules(rules, elements);
            return rules;
        }

        #region Create sets of Qualitative Rules
        private List<Rule> GetPowerSetOfRules(List<double> classes, int indexOfArgument)
        {
            List<string> set = CreateSetOfBinaryNumbers(classes);
            List<Rule> uniqueRules = CreateSetOfUniqueRules(set, classes);
            for(int i=0;i<uniqueRules.Count;i++)
            {
                uniqueRules[i].IndexOfArgument = indexOfArgument;
                uniqueRules[i].IsQualitative = true;
            }
            return uniqueRules;
        }

        private List<string> CreateSetOfBinaryNumbers(List<double> list)
        {
            List<string> set = new List<string>();
            for (int i = 0; i < Math.Pow(2, list.Count); i++)
            {
                string str = Convert.ToString(i, 2);
                while (str.Length != list.Count)
                    str = str.Insert(0, "0");
                set.Add(str);
            }
            return set;
        }

        private List<Rule> CreateSetOfUniqueRules(List<string> list, List<double> classes)
        {
            List<Rule> allRules = CreateSetOfAllRules(list, classes);
            List<Rule> uniqueRules = new List<Rule>();
            for (int i = 0; i < allRules.Count; i++)
            {
                if (!(allRules[i].Rules.Count == 0 || allRules[i].Rules.Count == classes.Count))
                {
                    allRules[i].Rules.Sort();
                    if (!uniqueRules.Contains(allRules[i]))
                        uniqueRules.Add(allRules[i]);
                }
            }
            return uniqueRules;
        }

        private List<Rule> CreateSetOfAllRules(List<string> list, List<double> classes)
        {
            List<Rule> rules = new List<Rule>();
            for(int i=0;i<list.Count;i++)
            {
                Rule temp = new Rule();
                for(int j=0;j<list[i].Length;j++)
                {
                    if (list[i][j] == '1')
                        temp.Rules.Add(classes[j]);
                }
                rules.Add(temp);
            }
            return rules;
        }
        #endregion

        private void CountErrorInQualitativeRules(List<Rule> rules, Data[] elements)
        {
            for(int i=0;i<rules.Count;i++)
            {
                Data[] left = null, right = null;
                GeneralMethods.DivideSampleByQualitiveRule(out left, out right, elements, 
                    rules[i].Rules, rules[i].IndexOfArgument);
                rules[i].Error = GeneralMethods.CountError(left);
                rules[i].Error += GeneralMethods.CountError(right);
            }
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
                GeneralMethods.DivideSampleByNotQualitiveRule(out left, out right, elements, temp.Rules[0], indexOfArgument);
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

        public static double FindErrorInNode(Data[] elements, int allElements)
        {
            double error = GeneralMethods.CountError(elements) * elements.Length;
            return error / allElements;
        }
    }
}
