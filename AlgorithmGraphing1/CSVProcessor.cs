using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace AlgorithmGraphing1
{
    class CSVProcessor
    {
        
        public static Dictionary<string, PriceData> ProcessVIXFile(string filename)
        {
            var lines = File.ReadLines(filename);
            int ln = 0;
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Processing VIX File...");
            Dictionary<string, PriceData> priceData = new Dictionary<string, PriceData>();
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                if (ln++ <= 1) continue;
                // VIX ONLY:
                string date = values[0];
                string[] dspl = date.Split('/');
                int day = Int32.Parse(dspl[1]);
                int mo = Int32.Parse(dspl[0]);
                date = dspl[2] + "-" + mo.ToString("D2") + "-" + day.ToString("D2");

                decimal open = Decimal.Parse(values[1]);
                decimal high = Decimal.Parse(values[2]);
                decimal low = Decimal.Parse(values[3]);
                decimal close = Decimal.Parse(values[4]);

                PriceData pd = new PriceData(date, ln, open, close, high, low);
                priceData.Add(date, pd);
            }
            Console.WriteLine("Processed VIX File in " + sw.ElapsedMilliseconds + "ms");
            sw.Stop();
            return priceData;
        }

        public static Dictionary<string, PriceData> ProcessDataFile(string symbol, string datafile)
        {
            var lines = File.ReadLines(datafile);
            int ln = 0;
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Processing {0} Data File...", symbol);
            Dictionary<string, PriceData> priceData = new Dictionary<string, PriceData>();
            string dataOrder = "DOHLC";
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                if (ln++ == 0)
                {
                    char[] order = new char[values.Length];
                    for(int i = 0; i < values.Length; i++)
                    {
                        string col = values[i].Trim(' ').ToUpper();
                        order[i] = col[0];
                    }
                    dataOrder = new string(order);
                    continue;
                }
                string date = values[dataOrder.IndexOf('D')];
                decimal close = Decimal.Parse(values[dataOrder.IndexOf('C')]);
                decimal open = dataOrder.Contains("O") ? Decimal.Parse(values[dataOrder.IndexOf('O')]) : close;
                decimal high = dataOrder.Contains("H") ? Decimal.Parse(values[dataOrder.IndexOf('H')]) : Math.Max(open, close);
                decimal low = dataOrder.Contains("L") ? Decimal.Parse(values[dataOrder.IndexOf('L')]) : Math.Min(open, close);

                PriceData pd = new PriceData(date, ln, open, close, high, low);
                priceData.Add(date, pd);
            }
            Console.WriteLine("Processed {0} Data File in {1}ms", symbol, sw.ElapsedMilliseconds);
            sw.Stop();
            return priceData;
        }

    }
}
