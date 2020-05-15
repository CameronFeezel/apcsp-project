using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AlgorithmGraphing1
{
    class PriceFunctions
    {
        
        public static decimal PercentOpenDown(Dictionary<string, PriceData> prices)
        {
            decimal amt = 0;

            Dictionary<int, PriceData> priceList = new Dictionary<int, PriceData>();

            using (var en = prices.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    priceList.Add(en.Current.Value.index, en.Current.Value);
                }
            }

            foreach (var keypair in priceList)
            {
                PriceData price = keypair.Value;
                if (price.index == 0) continue;
                var lastPrice = priceList[price.index - 1];
                if (price.Open < lastPrice.Close) amt++;
            }

            return amt / ((decimal)prices.Count);
        }

        public static Dictionary<string, PriceData> next30Prices(string date, Dictionary<string, PriceData> prices)
        {
            Dictionary<int, PriceData> priceList = new Dictionary<int, PriceData>();

            using (var en = prices.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    priceList.Add(en.Current.Value.index, en.Current.Value);
                }
            }

            if (!prices.ContainsKey(date)) return null;

            int ind = prices[date].index;

            Dictionary<string, PriceData> finalPrices = new Dictionary<string, PriceData>();

            for(int i = 0; i < 30; i++)
            {
                while (priceList[ind + i] == null) ind++;
                finalPrices.Add(priceList[ind + i].Date, priceList[ind + i]);
            }
            return finalPrices;
        }

        public static decimal PercentOpenDownConditional(Dictionary<string, PriceData> prices, Predicate<KeyValuePair<string, PriceData>> predicate)
        {
            decimal amt = 0;
            decimal total = 0;

            Dictionary<int, PriceData> priceList = new Dictionary<int, PriceData>();

            using (var en = prices.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    priceList.Add(en.Current.Value.index, en.Current.Value);
                }
            }

            foreach (var keypair in priceList)
            {
                PriceData price = keypair.Value;
                if (price.index == 0) continue;
                if (!predicate.Invoke(new KeyValuePair<string, PriceData>(price.Date, price))) continue;
                var lastPrice = priceList[price.index - 1];
                total++;
                if (price.Open < lastPrice.Close) amt++;
            }

            return amt / total;
        }

        public static decimal AverageReturnAfterWeek(Dictionary<string, PriceData> prices, Predicate<KeyValuePair<string, PriceData>> predicate)
        {
            List<decimal> returns = new List<decimal>();

            Dictionary<int, PriceData> priceList = new Dictionary<int, PriceData>();

            using (var en = prices.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    priceList.Add(en.Current.Value.index, en.Current.Value);
                }
            }

            foreach (var keypair in priceList)
            {
                PriceData price = keypair.Value;
                if (!priceList.ContainsKey(price.index + 5)) continue;
                if (!predicate.Invoke(new KeyValuePair<string, PriceData>(price.Date, price))) continue;
                var nextPrice = priceList[price.index + 5];
                returns.Add((nextPrice.Close - price.Open) / price.Open);
                
            }

            return returns.Average();
        }

        public static List<decimal> ReturnsAfterWeek(Dictionary<string, PriceData> prices, Predicate<KeyValuePair<string, PriceData>> predicate)
        {
            List<decimal> returns = new List<decimal>();

            Dictionary<int, PriceData> priceList = new Dictionary<int, PriceData>();

            using (var en = prices.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    priceList.Add(en.Current.Value.index, en.Current.Value);
                }
            }

            foreach (var keypair in priceList)
            {
                PriceData price = keypair.Value;
                if (!priceList.ContainsKey(price.index + 5)) continue;
                if (!predicate.Invoke(new KeyValuePair<string, PriceData>(price.Date, price))) continue;
                var nextPrice = priceList[price.index + 5];
                returns.Add((nextPrice.Close - price.Open) / price.Open);

            }

            return returns;
        }

        public static Dictionary<string, decimal> DatedReturnsAfterWeek(Dictionary<string, PriceData> prices, Predicate<KeyValuePair<string, PriceData>> predicate)
        {
            Dictionary<string, decimal> returns = new Dictionary<string, decimal>();

            Dictionary<int, PriceData> priceList = new Dictionary<int, PriceData>();

            using (var en = prices.GetEnumerator())
            {
                while (en.MoveNext())
                {
                    priceList.Add(en.Current.Value.index, en.Current.Value);
                }
            }

            foreach (var keypair in priceList)
            {
                PriceData price = keypair.Value;
                if (!priceList.ContainsKey(price.index + 5)) continue;
                if (!predicate.Invoke(new KeyValuePair<string, PriceData>(price.Date, price))) continue;
                var nextPrice = priceList[price.index + 5];
                returns.Add(price.Date, (nextPrice.Close - price.Open) / price.Open);

            }

            return returns;
        }
    }
}
