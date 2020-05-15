using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections;
using System.Net;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Alpaca.Markets;

namespace AlgorithmGraphing1
{
    class Program
    {
        private static ChartManager chartManager;
        private static string vixfile = null;
        private static string spxfile = null;
        private static string outfile = null;
        private static string calcfile = null;
        private static string startdate = "2005-01-03";

        static void Main(string[] args)
        {

            if (!PromptInputs(args)) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            chartManager = new ChartManager(form, form.GetChart(), form.GetQueueLabel());

            Tests.BearishFlagPattern test = new Tests.BearishFlagPattern(chartManager, vixfile, outfile, new DateTime(2017, 1, 3), new DateTime(2019, 12, 17));
            Tests.CrossMovingAveragePattern matest = new Tests.CrossMovingAveragePattern(chartManager, vixfile, outfile, new DateTime(2012, 6, 4), new DateTime(2019, 12, 17));

            Thread thr = new Thread(async () =>
            {
                await matest.Run();
            });
            thr.Start();

            Application.Run(form);

        }

        public enum ButtonClick
        {
            YES, NO, SKIP
        }

        public static void SendClickToChartManager(ButtonClick click)
        {
            if (click == ButtonClick.YES) chartManager.ClickYes();
            else if (click == ButtonClick.NO) chartManager.ClickNo();
            else if (click == ButtonClick.SKIP) chartManager.ClickSkip();
        }

        static void ProcessPrices(Dictionary<string, PriceData> prices, Dictionary<string, PriceData> vixPrices, Chart chart)
        {

            List<string> highVixDates = vixPrices.Keys.Where(date => vixPrices[date].Open > 20).ToList();

            

        }

        static bool PromptInputs(string[] args)
        {
            if (args.Length > 0)
            {
                for (var i = 0; i < args.Length; i++)
                {
                    string a = args[i].ToLower();
                    if (a.StartsWith("--spxfile=") || a.StartsWith("-sf="))
                    {
                        a = a.Substring(a.IndexOf("=") + 1);
                        spxfile = a;
                        Console.WriteLine("Index: SPX - From File: " + a);
                        continue;
                    }
                    else if (a.StartsWith("--vixfile=") || a.StartsWith("-vf="))
                    {
                        a = a.Substring(a.IndexOf("=") + 1);
                        vixfile = a;
                        Console.WriteLine("Index: VIX - From File: " + a);
                        continue;
                    }
                    else if (a.StartsWith("--outfile=") || a.StartsWith("-of="))
                    {
                        a = a.Substring(a.IndexOf("=") + 1);
                        outfile = a;
                        Console.WriteLine("Raw Output File: {0}", a);
                        continue;
                    }
                    else if (a.StartsWith("--calcfile=") || a.StartsWith("-cf="))
                    {
                        a = a.Substring(a.IndexOf("=") + 1);
                        calcfile = a;
                        Console.WriteLine("Calculated Output File: {0}", a);
                        continue;
                    }
                }
            }
            if (vixfile == null
                || spxfile == null
                || outfile == null
                || calcfile == null
                || startdate == null)
            {
                return false;
            }
            return true;
        }
    }
}
