using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorithmGraphing1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        public Chart GetChart()
        {
            return chart1;
        }

        public ToolStripLabel GetQueueLabel()
        {
            return labelQueue;
        }

        public ToolStripLabel GetProfitLabel()
        {
            return profitLabel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            Program.SendClickToChartManager(Program.ButtonClick.YES);
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            Program.SendClickToChartManager(Program.ButtonClick.NO);
        }

        private void buttonSkip_Click(object sender, EventArgs e)
        {
            Program.SendClickToChartManager(Program.ButtonClick.SKIP);
        }
    }
}
