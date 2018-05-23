using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionTree;

namespace DiplomaRegressionTree
{
    public partial class Form1 : Form
    {
        public RegressionTree Tree { get; set; }
        public const double Penalty = 0.1;

        public Form1()
        {
            InitializeComponent();            
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var linesFromFile = new List<string>();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    while (!sr.EndOfStream)
                        linesFromFile.Add(sr.ReadLine());
                }
                Tree = new RegressionTree(linesFromFile, Penalty);
            }
            fillRegressionChart();
        }

        private void fillRegressionChart()
        {
            drawCorrelationField();
            drawRegressionLine();
        }

        private void drawCorrelationField()
        {
            RegressionChart.Series["CorrelationField"].Points.Clear();
            for (int i = 0; i < Tree.Head.Elements.Length; i++)
                RegressionChart.Series["CorrelationField"].Points.AddXY(Tree.Head.Elements[i].Arguments[0],
                    Tree.Head.Elements[i].Y);
        }

        private void drawRegressionLine()
        {
            RegressionChart.Series["RegressionLine"].Points.Clear();
            var averageY = new List<double>();
            var minX = new List<double>();
            var maxX = new List<double>();
            findArgumentsOfRegressionLine(averageY, minX, maxX);
            for (int i = 0; i < averageY.Count; i++)
            {
                RegressionChart.Series["RegressionLine"].Points.AddXY(minX[i], averageY[i]);
                RegressionChart.Series["RegressionLine"].Points.AddXY(maxX[i], averageY[i]);
            }
        }

        private void SortMaxMinX(List<double> minX, List<double> maxX)
        {
            var d = new Dictionary<double, double>();
            for (int i = 0; i < minX.Count; i++)
                d.Add(minX[i], maxX[i]);
            //d.OrderBy(key => key.Value);
            int counter = 0;
            foreach (var pair in d.OrderBy(key => key.Value))
            {
                minX[counter] = pair.Key;
                maxX[counter] = pair.Value;
                counter++;
            }
        }

        private void findArgumentsOfRegressionLine(List<double> averageY, List<double> minX, List<double> maxX)
        {
            var qu = new Queue<DecisionTreeNode>();
            qu.Enqueue(Tree.Head);
            while (qu.Count != 0)
            {
                DecisionTreeNode tempNode = qu.Dequeue();
                if (tempNode.IsLeaf)
                {
                    //averageY.Add(countAverageYInLeaf(tempNode));
                    minX.Add(findMinXInLeaf(tempNode));
                    maxX.Add(findMaxXInLeaf(tempNode));
                }
                else
                {
                    qu.Enqueue(tempNode.LeftChild);
                    qu.Enqueue(tempNode.RightChild);
                }
            }
            SortMaxMinX(minX, maxX);
            for (int i = 0; i < minX.Count; i++)
                averageY.Add(Tree.Deside(minX[i]));
        }

        private double countAverageYInLeaf(DecisionTreeNode node)
        {
            double answer = 0;
            for (int i = 0; i < node.Elements.Length; i++)
                answer += node.Elements[i].Y;
            return answer / node.Elements.Length;
        }

        private double findMinXInLeaf(DecisionTreeNode node)
        {
            double answer = 1000000;
            for(int i = 0; i < node.Elements.Length; i++)
            {
                if (node.Elements[i].Arguments[0] < answer)
                    answer = node.Elements[i].Arguments[0];
            }
            return answer;
        }

        private double findMaxXInLeaf(DecisionTreeNode node)
        {
            double answer = -1000000;
            for (int i = 0; i < node.Elements.Length; i++)
            {
                if (node.Elements[i].Arguments[0] > answer)
                    answer = node.Elements[i].Arguments[0];
            }
            return answer;
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            TreeForm treeForm = new TreeForm(Tree);
            treeForm.Show();
        }

        private void btnDecide_Click(object sender, EventArgs e)
        {
            if(Tree != null)
            {
                double x = Convert.ToDouble(textBox1.Text);
                textBox2.Text = Tree.Deside(x).ToString();
            }
        }
    }
}
