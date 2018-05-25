using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using DecisionTree;
using RandomForestLibrary;
using System.Drawing;

namespace DiplomaRegressionTree
{
    public partial class Form1 : Form
    {
        public RegressionTree Tree { get; set; }
        public RandomForest Forest { get; set; }
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
                Data[] dataSet = Data.CreateDataSample(linesFromFile);
                Test testDataSet = new Test(dataSet);
                Tree = new RegressionTree(testDataSet, Penalty);
                Forest = new RandomForest(dataSet, 100, Penalty);
            }
            fillRegressionChart();
            fillRandomForestChart();
        }

        private void fillRegressionChart()
        {
            var treeVisualizator = new RegressionTreeVisualizator(Tree, RegressionChart);
            treeVisualizator.DrawCorrelationField();
            treeVisualizator.DrawRegressionLine("RegressionLine");
            var forestVisualizator = new RegressionTreeVisualizator(Tree, RandomForestChart);
            forestVisualizator.DrawCorrelationField();
        }

        private void fillRandomForestChart()
        {
            for(int i = 0; i < Forest.AmountOfTrees; i++)
            {
                var treeVisualizator = new RegressionTreeVisualizator(Forest.Trees[i], RandomForestChart);
                RandomForestChart.Series.Add(Forest.Trees[i].Name);
                RandomForestChart.Series[Forest.Trees[i].Name].Color = Color.Red;
                RandomForestChart.Series[Forest.Trees[i].Name].BorderWidth = 1;
                RandomForestChart.Series[Forest.Trees[i].Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                treeVisualizator.DrawRegressionLine(Forest.Trees[i].Name);
            }
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
