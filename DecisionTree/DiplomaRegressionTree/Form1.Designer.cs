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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.RegressionChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnDecide = new System.Windows.Forms.Button();
            this.panelPaint = new System.Windows.Forms.Panel();
            this.pictureBoxPaintTree = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RegressionChart)).BeginInit();
            this.panelPaint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaintTree)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(841, 504);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(163, 49);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open file...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // RegressionChart
            // 
            chartArea5.Name = "ChartArea1";
            this.RegressionChart.ChartAreas.Add(chartArea5);
            this.RegressionChart.Location = new System.Drawing.Point(793, 28);
            this.RegressionChart.Name = "RegressionChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series9.Name = "CorrelationField";
            series10.BorderColor = System.Drawing.Color.White;
            series10.BorderWidth = 3;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series10.Color = System.Drawing.Color.Red;
            series10.Name = "RegressionLine";
            this.RegressionChart.Series.Add(series9);
            this.RegressionChart.Series.Add(series10);
            this.RegressionChart.Size = new System.Drawing.Size(370, 300);
            this.RegressionChart.TabIndex = 1;
            this.RegressionChart.Text = "chart1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(841, 361);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(841, 387);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // btnDecide
            // 
            this.btnDecide.Location = new System.Drawing.Point(947, 372);
            this.btnDecide.Name = "btnDecide";
            this.btnDecide.Size = new System.Drawing.Size(75, 23);
            this.btnDecide.TabIndex = 5;
            this.btnDecide.Text = "Decide";
            this.btnDecide.UseVisualStyleBackColor = true;
            this.btnDecide.Click += new System.EventHandler(this.btnDecide_Click);
            // 
            // panelPaint
            // 
            this.panelPaint.AutoScroll = true;
            this.panelPaint.Controls.Add(this.pictureBoxPaintTree);
            this.panelPaint.Location = new System.Drawing.Point(3, 3);
            this.panelPaint.Name = "panelPaint";
            this.panelPaint.Size = new System.Drawing.Size(784, 573);
            this.panelPaint.TabIndex = 6;
            // 
            // pictureBoxPaintTree
            // 
            this.pictureBoxPaintTree.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxPaintTree.Name = "pictureBoxPaintTree";
            this.pictureBoxPaintTree.Size = new System.Drawing.Size(760, 550);
            this.pictureBoxPaintTree.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPaintTree.TabIndex = 0;
            this.pictureBoxPaintTree.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 588);
            this.Controls.Add(this.panelPaint);
            this.Controls.Add(this.btnDecide);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RegressionChart);
            this.Controls.Add(this.btnOpenFile);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.RegressionChart)).EndInit();
            this.panelPaint.ResumeLayout(false);
            this.panelPaint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaintTree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.DataVisualization.Charting.Chart RegressionChart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnDecide;
        private System.Windows.Forms.Panel panelPaint;
        private System.Windows.Forms.PictureBox pictureBoxPaintTree;
    }
}

