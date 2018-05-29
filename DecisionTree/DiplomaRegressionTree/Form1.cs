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
        private Test TestDataSet { get; set; }
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
                closePermissions();
                var linesFromFile = new List<string>();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    while (!sr.EndOfStream)
                        linesFromFile.Add(sr.ReadLine());
                }
                dataSet = Data.CreateDataSample(linesFromFile);
                TestDataSet = new Test(dataSet);
                Tree = new RegressionTree(TestDataSet, "Single Tree", Penalty);
                addTreePermissions();
                fillRegressionChart();
                cbTrees.Items.Add("Single Tree");
                MessageBox.Show("Tree was build.");
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            if (cbTrees.Text == string.Empty)
                MessageBox.Show("Choose tree for visualization, please!", "Error");
            else
            {
                TreeForm treeForm = null;
                if (cbTrees.Text == "Single Tree")
                    treeForm = new TreeForm(Tree);
                else
                {
                    for(int i=0;i<AmountOfTreesInForest;i++)
                        if(cbTrees.Text == Forest.Trees[i].Name)
                        {
                            treeForm = new TreeForm(Forest.Trees[i]);
                            break;
                        }
                }
                treeForm.Show();
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
                fillRandomForestChart();
                addItemsInDrawComboBox();
                MessageBox.Show("Forest was build.");
            }
            else MessageBox.Show("Input integer value in /Amount of trees/ field!", "Error");
        }

        private void addItemsInDrawComboBox()
        {
            for (int i = cbTrees.Items.Count - 1; i >= 1; i--)
                cbTrees.Items.RemoveAt(i);
            for (int i = 0; i < Forest.Trees.Count; i++)
                cbTrees.Items.Add(Forest.Trees[i].Name);
        }

        private void closePermissions()
        {
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDecideTree.Enabled = false;
            btnDraw.Enabled = false;
        }

        #region Tree
        private void addTreePermissions()
        {
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnDecideTree.Enabled = true;
            btnDraw.Enabled = true;
            btnTest.Enabled = true;
        }

        private void fillRegressionChart()
        {
            if (dataSet[0].AmountOfArguments == 1)
            {
                RegressionTreeVisualizator.ClearChart(RegressionChart);
                RegressionTreeVisualizator.DrawCorrelationField(dataSet, RegressionChart);
                var treeVisualizator = new RegressionTreeVisualizator(Tree, RegressionChart);
                treeVisualizator.DrawRegressionLine("RegressionLine");
            }
        }
        #endregion

        #region Forest
        private void addForestPermission()
        {
            btnDecideForest.Enabled = true;
        }

        private void fillRandomForestChart()
        {
            if (dataSet[0].AmountOfArguments == 1)
            {
                RegressionTreeVisualizator.ClearChart(RandomForestChart);
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
        }
        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double penalty;
            if (Double.TryParse(tbPenalty.Text, out penalty))
            {
                Penalty = penalty;
                if (Tree != null)
                {
                    Tree = new RegressionTree(TestDataSet, "Single Tree", Penalty);
                    RegressionTreeVisualizator.ClearChart(RegressionChart);
                    fillRegressionChart();
                }
                if (Forest != null)
                {
                    Forest = new RandomForest(dataSet, AmountOfTreesInForest, Penalty);
                    RegressionTreeVisualizator.ClearChart(RandomForestChart);
                    fillRandomForestChart();
                }
            }
            else MessageBox.Show("Input double value in /Penalty on leaves amount/ field!", "Error");
        }

        private void btnDecide_Click(object sender, EventArgs e)
        {
            double[] x = null;
            try
            { x = parseParametersLine(); }
            catch
            { MessageBox.Show("Input double values separated by one space in /Parameters/ field!", "Error"); }
            if (Tree != null)
                tbAnswerTree.Text = Tree.Deside(x).ToString();
            }

        private void btnDecideForest_Click(object sender, EventArgs e)
        {
            double[] x = null;
            try
            { x = parseParametersLine(); }
            catch
            { MessageBox.Show("Input double values separated by one space in /Parameters/ field!", "Error"); }
            if (Forest != null)
                tbAnswerForest.Text = Forest.Decide(x).ToString();
        }

        private double[] parseParametersLine()
        {
            string[] parameters = tbParameters.Text.Split(' ');
            var resParametrs = new double[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                resParametrs[i] = Convert.ToDouble(parameters[i]);
            }
            return resParametrs;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Data[] dataSet;
                var linesFromFile = new List<string>();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    while (!sr.EndOfStream)
                        linesFromFile.Add(sr.ReadLine());
                }
                dataSet = Data.CreateDataSample(linesFromFile);
                tbResultPenalty.Text = Penalty.ToString();
                tbResultAmountOfTrees.Text = AmountOfTreesInForest.ToString();
                tbResultTreeError.Text = Math.Round(Tree.TestDataSet(dataSet), 4).ToString();
                if (Forest != null)
                    tbResultForestError.Text = Math.Round(Forest.TestDataSet(dataSet), 4).ToString();
            }
        }
    }
}
