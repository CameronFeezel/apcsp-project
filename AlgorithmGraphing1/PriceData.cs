using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmGraphing1
{
    class PriceData
    {
        public string Date { get; }
        public int index { get; }
        public decimal Open { get; }
        public decimal Close { get; }
        public decimal High { get; }
        public decimal Low { get; }

        public PriceData(string Date, int index, decimal Open, decimal Close, decimal High, decimal Low)
        {
            this.Date = Date;
            this.index = index;
            this.Open = Open;
            this.Close = Close;
            this.Low = Low;
            this.High = High;
        }

        public PriceData(string Date, int index, decimal Open, decimal Close) :
            this(Date, index, Open, Close, Math.Max(Open, Close), Math.Min(Open, Close))
        {
        }

        public DateTime GetDateTime()
        {
            var arr = this.Date.Split('-');
            return new DateTime(int.Parse(arr[0]), int.Parse(arr[1]), int.Parse(arr[2]));
        }

    }
}
