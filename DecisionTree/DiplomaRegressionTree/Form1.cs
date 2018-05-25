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
        private RegressionTree Tree { get; set; }
        private RandomForest Forest { get; set; }
        private Data[] dataSet { get; set; }
        private double Penalty { get; set; }
        private int AmountOfTreesInForest { get; set; }

        public Form1()
        {
            InitializeComponent();
            Penalty = Convert.ToDouble(tbPenalty.Text);
            AmountOfTreesInForest = Convert.ToInt32(tbAmountOfTrees.Text);
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
                dataSet = Data.CreateDataSample(linesFromFile);
                Test testDataSet = new Test(dataSet);
                Tree = new RegressionTree(testDataSet, "Single Tree", Penalty);
                addTreePermissions();
            }
            fillRegressionChart();
            fillRandomForestChart();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            TreeForm treeForm = new TreeForm(Tree);
            treeForm.Show();
        }

        private void btnDecide_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(tbParameters.Text);
            if (Tree != null)
            {
                tbAnswerTree.Text = Tree.Deside(x).ToString();
            }
            if(Forest != null)
            {
                tbAnswerForest.Text = Forest.Decide(x).ToString();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int amountOfT;
            if (Int32.TryParse(tbAmountOfTrees.Text, out amountOfT))
            {
                AmountOfTreesInForest = Math.Abs(amountOfT);
                Forest = new RandomForest(dataSet, AmountOfTreesInForest, Penalty);
                addForestPermission();
            }
            else MessageBox.Show("Error", "Input integer value in /Amount of trees/ field");
        }

        #region Tree
        private void addTreePermissions()
        {
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnDecideTree.Enabled = true;
            btnDraw.Enabled = true;
        }

        private void fillRegressionChart()
        {
            RegressionTreeVisualizator.DrawCorrelationField(dataSet, RegressionChart);
            var treeVisualizator = new RegressionTreeVisualizator(Tree, RegressionChart);
            treeVisualizator.DrawRegressionLine("RegressionLine");
        }
        #endregion

        #region Forest
        private void addForestPermission()
        {
            btnDecideForest.Enabled = true;
        }

        private void fillRandomForestChart()
        {
            RegressionTreeVisualizator.DrawCorrelationField(dataSet, RandomForestChart);
            for (int i = 0; i < Forest.AmountOfTrees; i++)
            {
                var treeVisualizator = new RegressionTreeVisualizator(Forest.Trees[i], RandomForestChart);
                RandomForestChart.Series.Add(Forest.Trees[i].Name);
                RandomForestChart.Series[Forest.Trees[i].Name].Color = Color.Red;
                RandomForestChart.Series[Forest.Trees[i].Name].BorderWidth = 1;
                RandomForestChart.Series[Forest.Trees[i].Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
                treeVisualizator.DrawRegressionLine(Forest.Trees[i].Name);
            }
        }
        #endregion
    }
}
