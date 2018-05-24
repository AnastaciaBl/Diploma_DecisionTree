using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DecisionTree;
using RandomForestLibrary;

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
            }
            fillRegressionChart();
        }

        private void fillRegressionChart()
        {
            //drawCorrelationField();
            //drawRegressionLine();
            RegressionTreeVisualizator treeVisualizator = new RegressionTreeVisualizator(Tree, RegressionChart);
            treeVisualizator.DrawCorrelationField();
            treeVisualizator.DrawRegressionLine("RegressionLine");
        }

        private void fillRandomForestChart()
        {
            
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
