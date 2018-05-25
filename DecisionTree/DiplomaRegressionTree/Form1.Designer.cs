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
            this.Tables = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPenalty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAmountOfTrees = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAnswerForest = new System.Windows.Forms.TextBox();
            this.btnDecideForest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RegressionChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomForestChart)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Graphics.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(10, 19);
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
            this.RegressionChart.Location = new System.Drawing.Point(6, 6);
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
            this.RegressionChart.Size = new System.Drawing.Size(450, 365);
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
            this.btnDraw.Location = new System.Drawing.Point(663, 552);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(177, 49);
            this.btnDraw.TabIndex = 6;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // RandomForestChart
            // 
            chartArea2.Name = "ChartArea1";
            this.RandomForestChart.ChartAreas.Add(chartArea2);
            this.RandomForestChart.Location = new System.Drawing.Point(466, 6);
            this.RandomForestChart.Name = "RandomForestChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Name = "CorrelationField";
            this.RandomForestChart.Series.Add(series3);
            this.RandomForestChart.Size = new System.Drawing.Size(450, 365);
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
            this.tabControl1.Size = new System.Drawing.Size(936, 665);
            this.tabControl1.TabIndex = 8;
            // 
            // Graphics
            // 
            this.Graphics.Controls.Add(this.groupBox3);
            this.Graphics.Controls.Add(this.groupBox2);
            this.Graphics.Controls.Add(this.groupBox1);
            this.Graphics.Controls.Add(this.RegressionChart);
            this.Graphics.Controls.Add(this.btnDraw);
            this.Graphics.Controls.Add(this.RandomForestChart);
            this.Graphics.Location = new System.Drawing.Point(4, 22);
            this.Graphics.Name = "Graphics";
            this.Graphics.Padding = new System.Windows.Forms.Padding(3);
            this.Graphics.Size = new System.Drawing.Size(928, 639);
            this.Graphics.TabIndex = 0;
            this.Graphics.Text = "Graphics";
            this.Graphics.UseVisualStyleBackColor = true;
            // 
            // Tables
            // 
            this.Tables.Location = new System.Drawing.Point(4, 22);
            this.Tables.Name = "Tables";
            this.Tables.Padding = new System.Windows.Forms.Padding(3);
            this.Tables.Size = new System.Drawing.Size(843, 554);
            this.Tables.TabIndex = 1;
            this.Tables.Text = "Tables";
            this.Tables.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(673, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Draw:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDecideForest);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.btnDecideTree);
            this.groupBox2.Location = new System.Drawing.Point(261, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 257);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decide:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.tbPenalty);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnOpenFile);
            this.groupBox3.Location = new System.Drawing.Point(8, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(231, 256);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCreate);
            this.groupBox4.Controls.Add(this.tbAmountOfTrees);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(10, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 100);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Forest:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Penalty on leaves amount:";
            // 
            // tbPenalty
            // 
            this.tbPenalty.Location = new System.Drawing.Point(145, 175);
            this.tbPenalty.Name = "tbPenalty";
            this.tbPenalty.Size = new System.Drawing.Size(78, 20);
            this.tbPenalty.TabIndex = 13;
            this.tbPenalty.Text = "0.1";
            this.tbPenalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // tbAmountOfTrees
            // 
            this.tbAmountOfTrees.Location = new System.Drawing.Point(100, 23);
            this.tbAmountOfTrees.Name = "tbAmountOfTrees";
            this.tbAmountOfTrees.Size = new System.Drawing.Size(102, 20);
            this.tbAmountOfTrees.TabIndex = 14;
            this.tbAmountOfTrees.Text = "100";
            this.tbAmountOfTrees.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(33, 211);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(152, 31);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(23, 54);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(152, 33);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Parametrs (x1 x2 ... xN):";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Forest`s answer:";
            // 
            // tbAnswerForest
            // 
            this.tbAnswerForest.Location = new System.Drawing.Point(131, 70);
            this.tbAnswerForest.Name = "tbAnswerForest";
            this.tbAnswerForest.ReadOnly = true;
            this.tbAnswerForest.Size = new System.Drawing.Size(151, 20);
            this.tbAnswerForest.TabIndex = 6;
            // 
            // btnDecideForest
            // 
            this.btnDecideForest.Location = new System.Drawing.Point(29, 202);
            this.btnDecideForest.Name = "btnDecideForest";
            this.btnDecideForest.Size = new System.Drawing.Size(238, 41);
            this.btnDecideForest.TabIndex = 10;
            this.btnDecideForest.Text = "Decide Forest";
            this.btnDecideForest.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 669);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Regression Tree, Anastasiia Blyzniuk (PZ-14-1)";
            ((System.ComponentModel.ISupportInitialize)(this.RegressionChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RandomForestChart)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Graphics.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
    }
}

