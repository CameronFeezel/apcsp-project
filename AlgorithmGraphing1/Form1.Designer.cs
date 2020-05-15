namespace AlgorithmGraphing1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.stripPrevious = new System.Windows.Forms.ToolStrip();
            this.buttonYes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonNo = new System.Windows.Forms.ToolStripButton();
            this.buttonSkip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.labelQueue = new System.Windows.Forms.ToolStripLabel();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.profitLabel = new System.Windows.Forms.ToolStripLabel();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chartManagerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chartManagerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.stripPrevious.SuspendLayout();
            this.chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartManagerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartManagerBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.stripPrevious);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(747, 40);
            this.toolStripContainer1.ContentPanel.Load += new System.EventHandler(this.toolStripContainer1_ContentPanel_Load);
            this.toolStripContainer1.Location = new System.Drawing.Point(11, 397);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(747, 40);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // stripPrevious
            // 
            this.stripPrevious.Dock = System.Windows.Forms.DockStyle.None;
            this.stripPrevious.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profitLabel,
            this.buttonYes,
            this.toolStripSeparator1,
            this.buttonNo,
            this.buttonSkip,
            this.toolStripSeparator2,
            this.labelQueue});
            this.stripPrevious.Location = new System.Drawing.Point(110, 8);
            this.stripPrevious.Name = "stripPrevious";
            this.stripPrevious.Size = new System.Drawing.Size(517, 25);
            this.stripPrevious.TabIndex = 0;
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.Color.LightGreen;
            this.buttonYes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonYes.Image = ((System.Drawing.Image)(resources.GetObject("buttonYes.Image")));
            this.buttonYes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonYes.Margin = new System.Windows.Forms.Padding(8, 1, 0, 2);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(71, 22);
            this.buttonYes.Text = "YES Pattern";
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.LightCoral;
            this.buttonNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonNo.Image = ((System.Drawing.Image)(resources.GetObject("buttonNo.Image")));
            this.buttonNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonNo.Margin = new System.Windows.Forms.Padding(8, 1, 8, 2);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(70, 22);
            this.buttonNo.Text = "NO Pattern";
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonSkip
            // 
            this.buttonSkip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.buttonSkip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonSkip.Image = ((System.Drawing.Image)(resources.GetObject("buttonSkip.Image")));
            this.buttonSkip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSkip.Margin = new System.Windows.Forms.Padding(16, 1, 0, 2);
            this.buttonSkip.Name = "buttonSkip";
            this.buttonSkip.Size = new System.Drawing.Size(33, 22);
            this.buttonSkip.Text = "Skip";
            this.buttonSkip.Click += new System.EventHandler(this.buttonSkip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // labelQueue
            // 
            this.labelQueue.Font = new System.Drawing.Font("Open Sans Extrabold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQueue.Name = "labelQueue";
            this.labelQueue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelQueue.Size = new System.Drawing.Size(91, 22);
            this.labelQueue.Text = "0 in Queue";
            this.labelQueue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chartPanel
            // 
            this.chartPanel.Controls.Add(this.chart1);
            this.chartPanel.Location = new System.Drawing.Point(13, 13);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(746, 379);
            this.chartPanel.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.ScaleBreakStyle.Spacing = 1D;
            chartArea1.AxisY.Maximum = 1D;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(4, 4);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.DimGray;
            series1.CustomProperties = "PixelPointWidth=8, PriceDownColor=Red, PointWidth=0.2, PriceUpColor=LimeGreen";
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Lime;
            series1.Name = "Series1";
            series1.XValueMember = "Date";
            series1.YValueMembers = "Open";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(739, 372);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Open Sans Extrabold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "SPX";
            this.chart1.Titles.Add(title1);
            // 
            // profitLabel
            // 
            this.profitLabel.AutoSize = false;
            this.profitLabel.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.profitLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.profitLabel.Name = "profitLabel";
            this.profitLabel.Size = new System.Drawing.Size(140, 22);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(AlgorithmGraphing1.Program);
            // 
            // chartManagerBindingSource
            // 
            this.chartManagerBindingSource.DataSource = typeof(AlgorithmGraphing1.ChartManager);
            // 
            // chartManagerBindingSource1
            // 
            this.chartManagerBindingSource1.DataSource = typeof(AlgorithmGraphing1.ChartManager);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 450);
            this.Controls.Add(this.chartPanel);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.stripPrevious.ResumeLayout(false);
            this.stripPrevious.PerformLayout();
            this.chartPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartManagerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartManagerBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip stripPrevious;
        private System.Windows.Forms.ToolStripButton buttonNo;
        private System.Windows.Forms.ToolStripButton buttonYes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonSkip;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.BindingSource chartManagerBindingSource;
        private System.Windows.Forms.BindingSource chartManagerBindingSource1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel labelQueue;
        private System.Windows.Forms.ToolStripLabel profitLabel;
    }
}

