using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DecisionTree;
using System.Drawing;

namespace DiplomaRegressionTree
{
    public partial class TreeForm: Form
    {
        private struct Point
        {
            public int X;
            public int Y;
            public Point(int _x, int _y)
            {
                X = _x;
                Y = _y;
            }
        }

        private RegressionTree Tree { get; set; }
        private const int minStepForNodeVisualization = 35;
        private DecisionTreeNode[][] nodesForDraw;
        private int widthStep, heightStep, depthOfTree;
        private PictureBox pictureBoxPaintTree;

        private void InitializeComponent()
        {
            this.pictureBoxPaintTree = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaintTree)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPaintTree
            // 
            this.pictureBoxPaintTree.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPaintTree.Name = "pictureBoxPaintTree";
            this.pictureBoxPaintTree.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxPaintTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPaintTree.TabIndex = 0;
            this.pictureBoxPaintTree.TabStop = false;
            // 
            // TreeForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1308, 632);
            this.Controls.Add(this.pictureBoxPaintTree);
            this.Name = "TreeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaintTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public TreeForm()
        {
            InitializeComponent();
        }

        public TreeForm(RegressionTree tree):this()
        {
            Tree = tree;
            buildTree();
            pictureBoxPaintTree.Paint += drawTree;
        }

        private void buildTree()
        {
            depthOfTree = findDepth(1, Tree.Head);
            int amountOfNodesOnLastLayer = findAmountOfElementsInLastLayer(depthOfTree);
            nodesForDraw = createArrayOfLayersWithNodes(depthOfTree);
            findStepOfNodeShift(out widthStep, out heightStep, depthOfTree, amountOfNodesOnLastLayer);
        }

        private int findDepth(int d, DecisionTreeNode node)
        {
            int a = 0, b = 0;
            if (node.LeftChild != null)
                a = findDepth(d + 1, node.LeftChild);
            if (node.RightChild != null)
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

        private DecisionTreeNode[][] createArrayOfLayersWithNodes(int depthOfTree)
        {
            DecisionTreeNode[][] arrayOfLayers = new DecisionTreeNode[depthOfTree][];
            arrayOfLayers[0] = new DecisionTreeNode[1];
            for (int i = 1; i < arrayOfLayers.Length; i++)
            {
                arrayOfLayers[i] = new DecisionTreeNode[arrayOfLayers[i - 1].Length * 2];
            }
            arrayOfLayers[0][0] = Tree.Head;
            for (int i = 1; i < arrayOfLayers.Length; i++)
            {
                int indexOfCurrentLayer = 0;
                for (int j = 0; j < arrayOfLayers[i - 1].Length; j++)
                {
                    if (arrayOfLayers[i - 1][j] == null)
                    {
                        arrayOfLayers[i][indexOfCurrentLayer++] = null;
                        arrayOfLayers[i][indexOfCurrentLayer++] = null;
                    }
                    else
                    {
                        if (arrayOfLayers[i - 1][j].LeftChild != null)
                            arrayOfLayers[i][indexOfCurrentLayer++] = arrayOfLayers[i - 1][j].LeftChild;
                        else arrayOfLayers[i][indexOfCurrentLayer++] = null;
                        if (arrayOfLayers[i - 1][j].RightChild != null)
                            arrayOfLayers[i][indexOfCurrentLayer++] = arrayOfLayers[i - 1][j].RightChild;
                        else arrayOfLayers[i][indexOfCurrentLayer++] = null;
                    }
                }
            }
            return arrayOfLayers;
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
                pictureBoxPaintTree.Height = minHigth + minStepForNodeVisualization;
                heightStep = minStepForNodeVisualization;
            }
            else heightStep = pictureBoxPaintTree.Height / depthOfTree;
        }

        private void findSizeOfMinSpaceForTree(ref int width, ref int height, int depthOfTree, int amountOfNodesOnLastLayer)
        {
            width = minStepForNodeVisualization * amountOfNodesOnLastLayer;
            height = minStepForNodeVisualization * depthOfTree;
        }

        private void drawTree(object sender, PaintEventArgs e)
        {
            int height = minStepForNodeVisualization;
            int previousWidth = pictureBoxPaintTree.Width / 2;
            var previousLayerPoints = new List<Nullable<Point>>();
            for (int i = 0; i < nodesForDraw.Length; i++)
            {
                var currentPoints = new List<Nullable<Point>>();
                int width = previousWidth;
                for (int j = 0; j < nodesForDraw[i].Length; j++)
                {
                    drawNode(nodesForDraw[i][j], width, height, e.Graphics);

                    if (nodesForDraw[i][j] != null)
                        currentPoints.Add(new Point(width, height));
                    else currentPoints.Add(null);

                    width += previousWidth * 2;
                }
                drawEdges(currentPoints, previousLayerPoints, e.Graphics);
                previousLayerPoints = copyPoints(currentPoints);
                height += heightStep;
                previousWidth = previousWidth / 2;
            }
        }

        private void drawNode(DecisionTreeNode node, int x, int y, Graphics g)
        {
            if (node != null)
            {
                g.FillEllipse(new SolidBrush(Color.MidnightBlue), new Rectangle( x, y, 10, 10));
                g.DrawString(createTextOfRule(node), this.Font, new SolidBrush(Color.Black), x + 10, y - 20);
            }
        }

        private List<Nullable<Point>> copyPoints(List<Nullable<Point>> pointsForCopy)
        {
            var currentPoints = new List<Nullable<Point>>();
            for (int i = 0; i < pointsForCopy.Count; i++)
                currentPoints.Add(pointsForCopy[i]);
            return currentPoints;
        }

        private void drawEdges(List<Nullable<Point>> currentPoints, List<Nullable<Point>> previousLayerPoints, Graphics g)
        {
            if (previousLayerPoints.Count != 0 && currentPoints.Count != 0)
            {
                int indexOfPreviousLayerPoints = 0;
                for (int j = 0; j < currentPoints.Count; j++)
                {
                    if (currentPoints[j] == null)
                    {
                        indexOfPreviousLayerPoints++;
                        j++;
                    }
                    else
                    {
                        drawLine(previousLayerPoints[indexOfPreviousLayerPoints].Value.X, previousLayerPoints[indexOfPreviousLayerPoints].Value.Y,
                            currentPoints[j].Value.X, currentPoints[j].Value.Y, g);
                        j++;
                        drawLine(previousLayerPoints[indexOfPreviousLayerPoints].Value.X, previousLayerPoints[indexOfPreviousLayerPoints].Value.Y,
                            currentPoints[j].Value.X, currentPoints[j].Value.Y, g);
                        indexOfPreviousLayerPoints++;
                    }
                }
            }
        }

        private void drawLine(int x1, int y1, int x2, int y2, Graphics g)
        {
            g.DrawLine(new Pen(Color.Black, 1), x1, y1, x2, y2);
        }

        private string createTextOfRule(DecisionTreeNode node)
        {
            string str = string.Empty;
            if (node.Rule != null)
            {
                if (node.Rule.IsQualitative)
                {
                    str += String.Format("x[{0}]є", node.Rule.IndexOfArgument);
                    for (int i = 0; i < node.Rule.Rules.Count; i++)
                        str += node.Rule.Rules[i] + ";";
                }
                else
                    str = String.Format("x[{0}]:{1}", node.Rule.IndexOfArgument, Math.Round(node.Rule.Rules[0], 2).ToString());
            }
            return str;
        }
    }
}
