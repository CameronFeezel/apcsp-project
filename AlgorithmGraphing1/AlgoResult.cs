using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmGraphing1
{
    class AlgoResult
    {
        public readonly List<PriceData> Prices;
        public readonly decimal High;
        public readonly decimal Low;
        public readonly string Symbol;
        public readonly DateTime StartTime;
        public readonly DateTime EndTime;
        readonly bool PatternAlgFound;
        public bool PatternVisFound;

        public readonly Action<AlgoResult> TestCallback;

        readonly DateTime PositionOpenTime;
        readonly DateTime PositionCloseTime;
        readonly bool PositionLong;
        public readonly decimal PositionReturn;

        public AlgoResult(List<PriceData> prices, string symbol, DateTime startTime, DateTime endTime, bool patternAlgFound,
            Action<AlgoResult> testCallback, DateTime positionOpenTime, DateTime positionCloseTime, bool positionLong, decimal positionReturn)
        {
            Prices = prices;
            High = 0;
            Low = Decimal.MaxValue;
            foreach(var price in prices)
            {
                if (price.High > High) High = price.High;
                if (price.Low < Low) Low = price.Low;
            }
            Symbol = symbol;
            StartTime = startTime;
            EndTime = endTime;
            PatternAlgFound = patternAlgFound;
            TestCallback = testCallback;
            PositionOpenTime = positionOpenTime;
            PositionCloseTime = positionCloseTime;
            PositionLong = positionLong;
            PositionReturn = positionReturn;
        }

        /*
         * Symbol, Date, StartTime, EndTime, PatternAlgFound, PatternVisFound, PosOpenTime, PosCloseTime, PosLong, PosReturn
         * */
        public String ToCSVRow()
        {
            if (PatternAlgFound)
            {
                return string.Format("{0},{1:yyyy-MM-dd},{2:HH:mm},{3:HH:mm},{4:Yes;0;No},{5:Yes;0;No},{6:HH:mm},{7:HH:mm},{8:Long;0;Short},{9:P3}", Symbol, StartTime, StartTime, EndTime, PatternAlgFound.GetHashCode(), PatternVisFound.GetHashCode(), PositionOpenTime, PositionCloseTime, PositionLong.GetHashCode(), PositionReturn);
            }
            else
            {
                return string.Format("{0},{1:yyyy-MM-dd},{2:HH:mm},{3:HH:mm},{4:Yes;0;No},{5:Yes;0;No}", Symbol, StartTime, StartTime, EndTime, PatternAlgFound.GetHashCode(), PatternVisFound.GetHashCode());
            }
        }
    }
}
