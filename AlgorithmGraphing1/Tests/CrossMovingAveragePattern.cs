using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Alpaca.Markets;

namespace AlgorithmGraphing1.Tests
{
    class CrossMovingAveragePattern : AlgoTest
    {

        private string[] symbols = new string[]
        {
            "AAPL", "MSFT", "NFLX", "TSLA", "AAL", "BAC", "JPM"
        };

        private AlpacaTradingClient alpacaTradingClient;
        private AlpacaDataClient alpacaDataClient;

        private Guid lastTradeId = Guid.NewGuid();

        private Dictionary<string, PriceData> vixPrices;

        public CrossMovingAveragePattern(ChartManager chartManager, string vixPath, string outputPath, DateTime startDate, DateTime endDate
            ) : base(chartManager, startDate, endDate, vixPath, null, outputPath, null)
        {
        }

        public async Task Run()
        {
            Console.WriteLine("Updating VIX and SPX data");
            await ApplyUpdates(true, false);
            Console.WriteLine("Loading VIX file");
            vixPrices = CSVProcessor.ProcessVIXFile(VIXPath);

            Console.WriteLine("Connecting to alpaca trading API");
            alpacaTradingClient = Environments.Paper.GetAlpacaTradingClient(API_KEY, new SecretKey(API_SECRET));

            Console.WriteLine("Connecting to alpaca data API");
            alpacaDataClient = Environments.Paper.GetAlpacaDataClient(API_KEY, new SecretKey(API_SECRET));

            Console.WriteLine("Getting Market Calendars");
            var calendars = (await alpacaTradingClient.ListCalendarAsync(StartDate, EndDate)).ToList();

            Console.WriteLine("Writing header line in output file");
            using (StreamWriter w = File.CreateText(OutputPath))
            {
                w.WriteLine("Symbol, Date, StartTime, EndTime, PatternAlgFound, PatternVisFound, PosOpenTime, PosCloseTime, PosLong, PosReturn");
            }

            foreach (var calDate in calendars)
            {
                List<DateTime> startTimes = new List<DateTime>();
                DateTime loopTime = calDate.TradingOpenTime.AddMinutes(15);
                TimeSpan timeUntilClose = calDate.TradingCloseTime.Subtract(loopTime);
                while(timeUntilClose.TotalMinutes >= 30)
                {
                    startTimes.Add(loopTime);
                    loopTime = loopTime.Add(new TimeSpan(0, 30, 0));
                    timeUntilClose = calDate.TradingCloseTime.Subtract(loopTime);
                }

                // High volatility only.
                if (!vixPrices.ContainsKey(calDate.TradingDate.ToString("yyyy-MM-dd"))) continue;
                if (vixPrices[calDate.TradingDate.ToString("yyyy-MM-dd")].Open < 28) continue;

                foreach (DateTime dateTime in startTimes)
                {
                    var barSet = (await alpacaDataClient.GetBarSetAsync(symbols, TimeFrame.Minute, 60, true, dateTime.Subtract(TimeSpan.FromMinutes(14)), calDate.TradingCloseTime));


                    foreach (string sym in symbols)
                    {
                        if (!barSet.ContainsKey(sym)) continue;
                        var bars = barSet[sym].ToList();
                        // Pattern matching algorithm:
                        if (bars.Count < 44) continue;

                        int istr = 14;
                        int endtime = 14;
                        bool gr = false;
                        bool found = false;

                        for (int i = 14; i < 44; i++)
                        {
                            var price = bars[i];
                            if (price.Close - price.Open > 0)
                            {
                                if (gr) continue;

                                if (i - istr >= 4)
                                {
                                    found = true;
                                    endtime = i;
                                    break;
                                }

                                istr = i;
                                gr = true;
                            }
                            else
                            {
                                if (!gr) continue;

                                if (i - istr >= 6)
                                {
                                    found = true;
                                    endtime = i;
                                    break;
                                }

                                istr = i;
                                gr = false;
                            }
                        }

                        if (!found) continue;

                        bool lng = !gr;

                        decimal entPrice = bars[endtime].Close;
                        decimal exPrice = bars[43].Close;

                        decimal profit = lng ? exPrice - entPrice : entPrice - exPrice;
                        decimal pct = profit / entPrice;

                        // End of Algorithm - Should be a pattern match now

                        List<PriceData> prices = new List<PriceData>();
                        for (int i = 0; i < 30; i++) 
                        {
                            var price = bars[i+14];
                            prices.Add(new PriceData(price.Time.ToString("HH:mm"), i, price.Open, price.Close, price.High, price.Low));
                        }

                        AlgoResult match = new AlgoResult(prices, sym, dateTime, dateTime.AddMinutes(30), true, res => {
                            //WriteToOutput(res);
                        }, dateTime.AddMinutes(14+endtime), dateTime.AddMinutes(44), lng, pct);

                        ChartManager.SendToChartQueue(match);
                        match.PatternVisFound = true;
                        WriteToOutput(match);
                    }
                }
            }
            ChartManager.DoneProcessing();

        }

        public void WriteToOutput(AlgoResult res)
        {
            using (StreamWriter w = File.AppendText(OutputPath))
            {
                w.WriteLine(res.ToCSVRow());
            }
        }



    }
}
