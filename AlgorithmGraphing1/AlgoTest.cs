using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace AlgorithmGraphing1
{
    abstract class AlgoTest
    {

        // Inputs
        protected ChartManager ChartManager;
        protected string VIXPath = null;
        protected string SPXPath = null;
        protected string OutputPath = null;
        protected string CalcOutputPath = null;
        protected DateTime StartDate = DateTime.UtcNow.Subtract(new TimeSpan(365, 0, 0, 0));
        protected DateTime EndDate = DateTime.UtcNow;

        public AlgoTest(ChartManager chartManager, DateTime startDate, DateTime endDate, string vixPath = null, string spxPath = null, string outPath = null, string calcPath = null)
        {
            ChartManager = chartManager;
            VIXPath = vixPath;
            SPXPath = spxPath;
            OutputPath = outPath;
            CalcOutputPath = calcPath;
            StartDate = startDate;
            EndDate = endDate;


        }

        public async Task ApplyUpdates(bool updateVix = false, bool updateSpx = false)
        {

            if (updateVix)
            {
                WebClient client = new WebClient();
                await client.DownloadFileTaskAsync(new Uri("http://www.cboe.com/publish/scheduledtask/mktdata/datahouse/vixcurrent.csv"), VIXPath);
            }
            if (updateSpx)
            {
                WebClient client = new WebClient();
                await client.DownloadFileTaskAsync(new Uri("https://query1.finance.yahoo.com/v7/finance/download/%5EGSPC?period1=" + (TimeSpan.FromTicks(StartDate.ToUniversalTime().Ticks).TotalSeconds) + "&period2=" + (TimeSpan.FromTicks(EndDate.ToUniversalTime().Ticks).TotalSeconds) + "&interval=1d&events=history"), SPXPath);
            }
        }

        public AlgoTest(ChartManager chartManager, DateTime startDate, string vixPath = null, string spxPath = null, string outPath = null, string calcPath = null) :
            this(chartManager, startDate, DateTime.UtcNow, vixPath, spxPath, outPath, calcPath)
        {
        }
    }
}
