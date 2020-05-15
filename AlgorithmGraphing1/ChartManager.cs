using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace AlgorithmGraphing1
{
    class ChartManager
    {
        private AlgoResult ActiveResult;
        private readonly SynchronizationContext synchronizationContext;

        private Queue<AlgoResult> ChartQueue = new Queue<AlgoResult>();

        private Chart chart;
        private Form1 form1;
        private ToolStripLabel queueLabel;
        private ToolStripLabel profitLabel;
        private decimal totalCapital = 10000.0M;
        private double chartMin = 0;
        private double chartMax = 1;

        private bool doneProc = false;

        public ChartManager(Form1 form1, Chart chart, ToolStripLabel queueLabel)
        {
            this.chart = chart;
            this.form1 = form1;
            this.synchronizationContext = SynchronizationContext.Current;
            this.queueLabel = queueLabel;
            this.profitLabel = form1.GetProfitLabel();
        }

        public void ClickYes()
        {
            ActiveResult.PatternVisFound = true;
            ActiveResult.TestCallback.Invoke(ActiveResult);
            NextInQueue();
        }

        public void ClickNo()
        {
            ActiveResult.PatternVisFound = false;
            ActiveResult.TestCallback.Invoke(ActiveResult);
            NextInQueue();
        }

        public void ClickSkip()
        {
            ChartQueue.Enqueue(ActiveResult);
            queueLabel.Text = string.Format("{0} in Queue{1}", ChartQueue.Count, doneProc ? " (Done Processing)" : "");
            NextInQueue();
        }

        public void DoneProcessing()
        {
            doneProc = true;
        }

        private void NextInQueue()
        {
            Console.WriteLine("Showing Next");
            if (ChartQueue.Count == 0)
            {
                form1.Close();
                return;
            }
            ActiveResult = ChartQueue.Dequeue();
            queueLabel.Text = string.Format("{0} in Queue{1}", ChartQueue.Count, doneProc ? " (Done Processing)" : "");
            decimal ret = ActiveResult.PositionReturn;
            totalCapital += (totalCapital * ret);
            profitLabel.Text = string.Format("({0:P2}) {1:C0}", ret, totalCapital);
            this.chartMin = Decimal.ToDouble(ActiveResult.Low);
            this.chartMax = Decimal.ToDouble(ActiveResult.High);
            chart.Series["Series1"].XValueMember = "Date";
            chart.ChartAreas[0].AxisX.Title = ActiveResult.StartTime.ToString("yyyy-MM-dd");
            chart.Titles[0].Text = ActiveResult.Symbol.ToUpper();
            chart.Series["Series1"].YValueMembers = "High, Low, Open, Close";
            chart.Series["Series1"]["ShowOpenClose"] = "Both";
            chart.ChartAreas[0].AxisY.Maximum = Math.Round(chartMax, 4);
            chart.ChartAreas[0].AxisY.Minimum = Math.Round(chartMin, 4);
            chart.DataManipulator.IsStartFromFirst = true;
            chart.DataSource = ActiveResult.Prices;
            chart.DataBind();
        }

        public void SendToChartQueue(AlgoResult result)
        {
            Console.WriteLine("Sending this to queue: " + result.Symbol + result.StartTime.ToShortDateString() +
                              result.StartTime.ToShortTimeString());
            synchronizationContext.Post(new SendOrPostCallback(res =>
            {
                Console.WriteLine("Queueing");
                ChartQueue.Enqueue((AlgoResult)res);
                queueLabel.Text = string.Format("{0} in Queue{1}", ChartQueue.Count, doneProc ? " (Done Processing)" : "");
                if (ActiveResult == null)
                    NextInQueue();
            }), result);
        }
    }
}
