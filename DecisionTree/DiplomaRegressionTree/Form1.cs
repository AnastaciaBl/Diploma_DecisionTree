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
        private const int minStepForNodeVisualization = 30;

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
            buildTree();
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

        private void buildTree()
        {
            int depthOfTree = findDepth(1, Tree.Head);
            int amountOfNodesOnLastLayer = findAmountOfElementsInLastLayer(depthOfTree);
            DecisionTreeNode[][] nodesForDraw = createArrayOfLayersWithNodes(depthOfTree);
            int widthStep, heightStep;
            findStepOfNodeShift(out widthStep, out heightStep, depthOfTree, amountOfNodesOnLastLayer);
            drawNode(Tree.Head, 50, 0);
            //for (int i = nodesForDraw.Length - 1; i >= 0; i--)
            //{
            //    int height = pictureBoxPaintTree.Height;
            //    int width = (nodesForDraw[depthOfTree - 1].Length - nodesForDraw[i].Length) * widthStep;
            //    for (int j = 0; j < nodesForDraw[i].Length; j++)
            //    {
            //        drawNode(nodesForDraw[i][j], width, height);
            //        width += widthStep;
            //    }
            //    height -= heightStep;
            //}
            //drawNode(Tree.Head, (int)pictureBoxPaintTree.Width / 2, 0);
        }

        private void drawNode(DecisionTreeNode node, int x, int y)
        {
            if (node != null)
            {
                Graphics g = Graphics.FromHwnd(pictureBoxPaintTree.Handle);
                g.DrawEllipse(new Pen(Color.Black, 2), x, y, 5, 5);
                g.DrawString(createTextOfRule(node), this.Font, new SolidBrush(Color.Black), x + 10, y);
            }
        }

        private int findDepth(int d, DecisionTreeNode node)
        {
            int a = 0, b = 0;
            if (node.LeftChild != null)
                a = findDepth(d + 1, node.LeftChild);
            if(node.RightChild != null)
                b = findDepth(d + 1, node.RightChild);

            if (a > d && a > b) return a;
            if (b > d) return b;
            return d;
        }

        private int findAmountOfElementsInLastLayer(int depthOfTree)
        {
            int amountOfNodesOnLastLayer = 1;
            for (int i = 1; i < depthOfTree; i++)
                amountOfNodesOnLastLayer = amountOfNodesOnLastLayer * 2;
            return amountOfNodesOnLastLayer;
        }

        private void findStepOfNodeShift(out int widthStep, out int heightStep, int depthOfTree, int amountOfNodesOnLastLayer)
        {
            int minWidth = 0, minHigth = 0;
            findSizeOfMinSpaceForTree(ref minWidth, ref minHigth, depthOfTree, amountOfNodesOnLastLayer);
            if (minWidth > pictureBoxPaintTree.Width)
            {
                pictureBoxPaintTree.Width = minWidth;
                widthStep = minStepForNodeVisualization;
            }
            else widthStep = pictureBoxPaintTree.Width / amountOfNodesOnLastLayer;
            if (minHigth > pictureBoxPaintTree.Height)
            {
                pictureBoxPaintTree.Height = minHigth;
                heightStep = minStepForNodeVisualization;
            }
            else heightStep = pictureBoxPaintTree.Height / depthOfTree;
        }

        private void findSizeOfMinSpaceForTree(ref int width, ref int height, int depthOfTree, int amountOfNodesOnLastLayer)
        {
            width = minStepForNodeVisualization * amountOfNodesOnLastLayer;
            height = minStepForNodeVisualization * depthOfTree;
        }

        //private bool isNeedToChangePixtureBoxSize(int minWidth, int minHight)
        //{
        //    if (minWidth > pictureBoxPaintTree.Width || minHight > pictureBoxPaintTree.Height)
        //        return true;
        //    else return false;
        //}

        private DecisionTreeNode[][] createArrayOfLayersWithNodes(int depthOfTree)
        {
            DecisionTreeNode[][] arrayOfLayers = new DecisionTreeNode[depthOfTree][];
            arrayOfLayers[0] = new DecisionTreeNode[1];
            for (int i=1;i<arrayOfLayers.Length;i++)
            {
                arrayOfLayers[i] = new DecisionTreeNode[arrayOfLayers[i - 1].Length * 2];
            }
            arrayOfLayers[0][0] = Tree.Head;
            for(int i = 1; i < arrayOfLayers.Length; i++)
            {
                int indexOfCurrentLayer = 0;
                for(int j = 0;j < arrayOfLayers[i - 1].Length; j++)
                {
                    if (arrayOfLayers[i - 1][j] == null)
                    {
                        arrayOfLayers[i][indexOfCurrentLayer++] = null;
                        //indexOfCurrentLayer++;
                        arrayOfLayers[i][indexOfCurrentLayer++] = null;
                        //indexOfCurrentLayer++;
                    }
                    else
                    {
                        if (arrayOfLayers[i - 1][j].LeftChild != null)
                            arrayOfLayers[i][indexOfCurrentLayer++] = arrayOfLayers[i-1][j].LeftChild;
                        else arrayOfLayers[i][indexOfCurrentLayer++] = null;
                        if (arrayOfLayers[i - 1][j].RightChild != null)
                            arrayOfLayers[i][indexOfCurrentLayer++] = arrayOfLayers[i-1][j].RightChild;
                        else arrayOfLayers[i][indexOfCurrentLayer++] = null;
                    }
                }
            }
            return arrayOfLayers;
        }

        private string createTextOfRule(DecisionTreeNode node)
        {
            string str = string.Empty;
            if (node.Rule != null)
            {
                if (node.Rule.IsQualitative)
                {
                    str += String.Format("x[{0}]є ", node.Rule.IndexOfArgument);
                    for (int i = 0; i < node.Rule.Rules.Count; i++)
                        str += node.Rule.Rules[i] + ";";
                }
                else
                    str = String.Format("x[{0}]: {1}", node.Rule.IndexOfArgument, Math.Round(node.Rule.Rules[0], 3).ToString());
            }
            return str;
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
