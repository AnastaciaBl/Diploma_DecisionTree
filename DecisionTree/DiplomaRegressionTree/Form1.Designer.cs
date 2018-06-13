namespace DiplomaRegressionTree
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.RegressionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tbParameters = new System.Windows.Forms.TextBox();
            this.tbAnswerTree = new System.Windows.Forms.TextBox();
            this.btnDecideTree = new System.Windows.Forms.Button();
            this.btnDraw = new System.Windows.Forms.Button();
            this.RandomForestChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Graphics = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbResultForestError = new System.Windows.Forms.TextBox();
            this.tbResultTreeError = new System.Windows.Forms.TextBox();
            this.tbResultAmountOfTrees = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbResultPenalty = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbPenalty = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tbAmountOfTrees = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDecideForest = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbAnswerForest = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTrees = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Tables = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbTestPenalty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTestAmountOfParameters = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTestName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnChooseTest = new System.Windows.Forms.Button();
            this.btnDoTest = new System.Windows.Forms.Button();
            this.dataGridTest = new System.Windows.Forms.DataGridView();
            this.tbS2Tree = new System.Windows.Forms.TextBox();
            this.tbS2Forest = new System.Windows.Forms.TextBox();
            this.tbSTree = new System.Windows.Forms.TextBox();
            this.tbSForest = new System.Windows.Forms.TextBox();
            this.tbCoefTree = new System.Windows.Forms.TextBox();
            this.tbCoefForest = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.RegressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomForestChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Graphics.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Tables.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTest)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(18, 19);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(213, 32);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open file...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // RegressionChart
            // 
            chartArea1.Name = "ChartArea1";
            this.RegressionChart.ChartAreas.Add(chartArea1);
            this.RegressionChart.Location = new System.Drawing.Point(8, 6);
            this.RegressionChart.Name = "RegressionChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Legend = "Legend1";
            series1.Name = "CorrelationField";
            series2.BorderColor = System.Drawing.Color.White;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.Name = "RegressionLine";
            this.RegressionChart.Series.Add(series1);
            this.RegressionChart.Series.Add(series2);
            this.RegressionChart.Size = new System.Drawing.Size(531, 365);
            this.RegressionChart.TabIndex = 1;
            this.RegressionChart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            title1.Name = "RegressionTree";
            title1.Text = "Regression Tree";
            this.RegressionChart.Titles.Add(title1);
            // 
            // tbParameters
            // 
            this.tbParameters.Location = new System.Drawing.Point(131, 17);
            this.tbParameters.Name = "tbParameters";
            this.tbParameters.Size = new System.Drawing.Size(151, 20);
            this.tbParameters.TabIndex = 3;
            // 
            // tbAnswerTree
            // 
            this.tbAnswerTree.Location = new System.Drawing.Point(131, 43);
            this.tbAnswerTree.Name = "tbAnswerTree";
            this.tbAnswerTree.ReadOnly = true;
            this.tbAnswerTree.Size = new System.Drawing.Size(151, 20);
            this.tbAnswerTree.TabIndex = 4;
            // 
            // btnDecideTree
            // 
            this.btnDecideTree.Enabled = false;
            this.btnDecideTree.Location = new System.Drawing.Point(29, 141);
            this.btnDecideTree.Name = "btnDecideTree";
            this.btnDecideTree.Size = new System.Drawing.Size(238, 41);
            this.btnDecideTree.TabIndex = 5;
            this.btnDecideTree.Text = "Decide Tree";
            this.btnDecideTree.UseVisualStyleBackColor = true;
            this.btnDecideTree.Click += new System.EventHandler(this.btnDecide_Click);
            // 
            // btnDraw
            // 
            this.btnDraw.Enabled = false;
            this.btnDraw.Location = new System.Drawing.Point(36, 149);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(177, 72);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // RandomForestChart
            // 
            chartArea2.Name = "ChartArea1";
            this.RandomForestChart.ChartAreas.Add(chartArea2);
            this.RandomForestChart.Location = new System.Drawing.Point(546, 0);
            this.RandomForestChart.Name = "RandomForestChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Name = "CorrelationField";
            this.RandomForestChart.Series.Add(series3);
            this.RandomForestChart.Size = new System.Drawing.Size(531, 365);
            this.RandomForestChart.TabIndex = 7;
            this.RandomForestChart.Text = "chart1";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            title2.Name = "RandomForest";
            title2.Text = "Random Forest";
            this.RandomForestChart.Titles.Add(title2);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Graphics);
            this.tabControl1.Controls.Add(this.Tables);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1094, 665);
            this.tabControl1.TabIndex = 8;
            // 
            // Graphics
            // 
            this.Graphics.Controls.Add(this.groupBox7);
            this.Graphics.Controls.Add(this.groupBox3);
            this.Graphics.Controls.Add(this.groupBox2);
            this.Graphics.Controls.Add(this.groupBox1);
            this.Graphics.Controls.Add(this.RegressionChart);
            this.Graphics.Controls.Add(this.RandomForestChart);
            this.Graphics.Location = new System.Drawing.Point(4, 22);
            this.Graphics.Name = "Graphics";
            this.Graphics.Padding = new System.Windows.Forms.Padding(3);
            this.Graphics.Size = new System.Drawing.Size(1086, 639);
            this.Graphics.TabIndex = 0;
            this.Graphics.Text = "Graphics";
            this.Graphics.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbResultForestError);
            this.groupBox7.Controls.Add(this.tbResultTreeError);
            this.groupBox7.Controls.Add(this.tbResultAmountOfTrees);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.tbResultPenalty);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.btnTest);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Location = new System.Drawing.Point(826, 377);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(250, 257);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Result:";
            // 
            // tbResultForestError
            // 
            this.tbResultForestError.Location = new System.Drawing.Point(161, 132);
            this.tbResultForestError.Name = "tbResultForestError";
            this.tbResultForestError.ReadOnly = true;
            this.tbResultForestError.Size = new System.Drawing.Size(61, 20);
            this.tbResultForestError.TabIndex = 14;
            // 
            // tbResultTreeError
            // 
            this.tbResultTreeError.Location = new System.Drawing.Point(161, 106);
            this.tbResultTreeError.Name = "tbResultTreeError";
            this.tbResultTreeError.ReadOnly = true;
            this.tbResultTreeError.Size = new System.Drawing.Size(61, 20);
            this.tbResultTreeError.TabIndex = 13;
            // 
            // tbResultAmountOfTrees
            // 
            this.tbResultAmountOfTrees.Location = new System.Drawing.Point(161, 60);
            this.tbResultAmountOfTrees.Name = "tbResultAmountOfTrees";
            this.tbResultAmountOfTrees.ReadOnly = true;
            this.tbResultAmountOfTrees.Size = new System.Drawing.Size(61, 20);
            this.tbResultAmountOfTrees.TabIndex = 12;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Amount of trees in the forest:";
            // 
            // tbResultPenalty
            // 
            this.tbResultPenalty.Location = new System.Drawing.Point(161, 33);
            this.tbResultPenalty.Name = "tbResultPenalty";
            this.tbResultPenalty.ReadOnly = true;
            this.tbResultPenalty.Size = new System.Drawing.Size(61, 20);
            this.tbResultPenalty.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Penalty:";
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Location = new System.Drawing.Point(60, 185);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 44);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Forest`s error:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 109);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Tree`s error:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.tbPenalty);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnOpenFile);
            this.groupBox3.Location = new System.Drawing.Point(8, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 257);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(41, 211);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(152, 31);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbPenalty
            // 
            this.tbPenalty.Location = new System.Drawing.Point(153, 175);
            this.tbPenalty.Name = "tbPenalty";
            this.tbPenalty.Size = new System.Drawing.Size(78, 20);
            this.tbPenalty.TabIndex = 13;
            this.tbPenalty.Text = "0,1";
            this.tbPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreate);
            this.groupBox4.Controls.Add(this.tbAmountOfTrees);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(18, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 100);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Forest:";
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(23, 54);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(152, 33);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tbAmountOfTrees
            // 
            this.tbAmountOfTrees.Location = new System.Drawing.Point(100, 23);
            this.tbAmountOfTrees.Name = "tbAmountOfTrees";
            this.tbAmountOfTrees.Size = new System.Drawing.Size(102, 20);
            this.tbAmountOfTrees.TabIndex = 14;
            this.tbAmountOfTrees.Text = "100";
            this.tbAmountOfTrees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Amount of trees:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Penalty on leaves amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDecideForest);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnDecideTree);
            this.groupBox2.Location = new System.Drawing.Point(264, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 257);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decide:";
            // 
            // btnDecideForest
            // 
            this.btnDecideForest.Enabled = false;
            this.btnDecideForest.Location = new System.Drawing.Point(29, 202);
            this.btnDecideForest.Name = "btnDecideForest";
            this.btnDecideForest.Size = new System.Drawing.Size(238, 41);
            this.btnDecideForest.TabIndex = 10;
            this.btnDecideForest.Text = "Decide Forest";
            this.btnDecideForest.UseVisualStyleBackColor = true;
            this.btnDecideForest.Click += new System.EventHandler(this.btnDecideForest_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbAnswerForest);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.tbParameters);
            this.groupBox5.Controls.Add(this.tbAnswerTree);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(288, 106);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            // 
            // tbAnswerForest
            // 
            this.tbAnswerForest.Location = new System.Drawing.Point(131, 70);
            this.tbAnswerForest.Name = "tbAnswerForest";
            this.tbAnswerForest.ReadOnly = true;
            this.tbAnswerForest.Size = new System.Drawing.Size(151, 20);
            this.tbAnswerForest.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Forest`s answer:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tree`s answer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Parameters (x1 x2 ... xN):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTrees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnDraw);
            this.groupBox1.Location = new System.Drawing.Point(570, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 257);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw:";
            // 
            // cbTrees
            // 
            this.cbTrees.FormattingEnabled = true;
            this.cbTrees.Location = new System.Drawing.Point(6, 81);
            this.cbTrees.Name = "cbTrees";
            this.cbTrees.Size = new System.Drawing.Size(238, 21);
            this.cbTrees.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Choose tree for visualization:";
            // 
            // Tables
            // 
            this.Tables.Controls.Add(this.tbCoefForest);
            this.Tables.Controls.Add(this.tbCoefTree);
            this.Tables.Controls.Add(this.tbSForest);
            this.Tables.Controls.Add(this.tbSTree);
            this.Tables.Controls.Add(this.tbS2Forest);
            this.Tables.Controls.Add(this.tbS2Tree);
            this.Tables.Controls.Add(this.groupBox6);
            this.Tables.Controls.Add(this.dataGridTest);
            this.Tables.Location = new System.Drawing.Point(4, 22);
            this.Tables.Name = "Tables";
            this.Tables.Padding = new System.Windows.Forms.Padding(3);
            this.Tables.Size = new System.Drawing.Size(1086, 639);
            this.Tables.TabIndex = 1;
            this.Tables.Text = "Tables";
            this.Tables.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tbTestPenalty);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.tbTestAmountOfParameters);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.tbTestName);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.btnChooseTest);
            this.groupBox6.Controls.Add(this.btnDoTest);
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(916, 137);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Test info:";
            // 
            // tbTestPenalty
            // 
            this.tbTestPenalty.Location = new System.Drawing.Point(165, 91);
            this.tbTestPenalty.Name = "tbTestPenalty";
            this.tbTestPenalty.Size = new System.Drawing.Size(224, 20);
            this.tbTestPenalty.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Penalty of leaves`s amount: ";
            // 
            // tbTestAmountOfParameters
            // 
            this.tbTestAmountOfParameters.Location = new System.Drawing.Point(165, 60);
            this.tbTestAmountOfParameters.Name = "tbTestAmountOfParameters";
            this.tbTestAmountOfParameters.Size = new System.Drawing.Size(224, 20);
            this.tbTestAmountOfParameters.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Test`s name:";
            // 
            // tbTestName
            // 
            this.tbTestName.Location = new System.Drawing.Point(165, 28);
            this.tbTestName.Name = "tbTestName";
            this.tbTestName.Size = new System.Drawing.Size(224, 20);
            this.tbTestName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Amount of parameters:";
            // 
            // btnChooseTest
            // 
            this.btnChooseTest.Location = new System.Drawing.Point(415, 41);
            this.btnChooseTest.Name = "btnChooseTest";
            this.btnChooseTest.Size = new System.Drawing.Size(230, 57);
            this.btnChooseTest.TabIndex = 1;
            this.btnChooseTest.Text = "Choose test folder";
            this.btnChooseTest.UseVisualStyleBackColor = true;
            // 
            // btnDoTest
            // 
            this.btnDoTest.Location = new System.Drawing.Point(671, 41);
            this.btnDoTest.Name = "btnDoTest";
            this.btnDoTest.Size = new System.Drawing.Size(230, 57);
            this.btnDoTest.TabIndex = 2;
            this.btnDoTest.Text = "Start test!";
            this.btnDoTest.UseVisualStyleBackColor = true;
            // 
            // dataGridTest
            // 
            this.dataGridTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTest.Location = new System.Drawing.Point(6, 149);
            this.dataGridTest.Name = "dataGridTest";
            this.dataGridTest.Size = new System.Drawing.Size(916, 484);
            this.dataGridTest.TabIndex = 0;
            // 
            // tbS2Tree
            // 
            this.tbS2Tree.Location = new System.Drawing.Point(952, 149);
            this.tbS2Tree.Name = "tbS2Tree";
            this.tbS2Tree.Size = new System.Drawing.Size(100, 20);
            this.tbS2Tree.TabIndex = 3;
            // 
            // tbS2Forest
            // 
            this.tbS2Forest.Location = new System.Drawing.Point(952, 176);
            this.tbS2Forest.Name = "tbS2Forest";
            this.tbS2Forest.Size = new System.Drawing.Size(100, 20);
            this.tbS2Forest.TabIndex = 4;
            // 
            // tbSTree
            // 
            this.tbSTree.Location = new System.Drawing.Point(952, 306);
            this.tbSTree.Name = "tbSTree";
            this.tbSTree.Size = new System.Drawing.Size(100, 20);
            this.tbSTree.TabIndex = 5;
            // 
            // tbSForest
            // 
            this.tbSForest.Location = new System.Drawing.Point(952, 332);
            this.tbSForest.Name = "tbSForest";
            this.tbSForest.Size = new System.Drawing.Size(100, 20);
            this.tbSForest.TabIndex = 6;
            // 
            // tbCoefTree
            // 
            this.tbCoefTree.Location = new System.Drawing.Point(952, 416);
            this.tbCoefTree.Name = "tbCoefTree";
            this.tbCoefTree.Size = new System.Drawing.Size(100, 20);
            this.tbCoefTree.TabIndex = 7;
            // 
            // tbCoefForest
            // 
            this.tbCoefForest.Location = new System.Drawing.Point(952, 443);
            this.tbCoefForest.Name = "tbCoefForest";
            this.tbCoefForest.Size = new System.Drawing.Size(100, 20);
            this.tbCoefForest.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 669);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Regression Tree, Anastasiia Blyzniuk (PZ-14-1)";
            ((System.ComponentModel.ISupportInitialize)(this.RegressionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomForestChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Graphics.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Tables.ResumeLayout(false);
            this.Tables.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart RegressionChart;
        private System.Windows.Forms.TextBox tbParameters;
        private System.Windows.Forms.TextBox tbAnswerTree;
        private System.Windows.Forms.Button btnDecideTree;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.DataVisualization.Charting.Chart RandomForestChart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Graphics;
        private System.Windows.Forms.TabPage Tables;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox tbPenalty;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox tbAmountOfTrees;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDecideForest;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbAnswerForest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTrees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbTestPenalty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTestAmountOfParameters;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTestName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnChooseTest;
        private System.Windows.Forms.Button btnDoTest;
        private System.Windows.Forms.DataGridView dataGridTest;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbResultForestError;
        private System.Windows.Forms.TextBox tbResultTreeError;
        private System.Windows.Forms.TextBox tbResultAmountOfTrees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbResultPenalty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbS2Forest;
        private System.Windows.Forms.TextBox tbS2Tree;
        private System.Windows.Forms.TextBox tbSForest;
        private System.Windows.Forms.TextBox tbSTree;
        private System.Windows.Forms.TextBox tbCoefForest;
        private System.Windows.Forms.TextBox tbCoefTree;
    }
}

