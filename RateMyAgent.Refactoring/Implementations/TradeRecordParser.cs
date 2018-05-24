using RateMyAgent.Refactoring.Abstractions;
using RateMyAgent.Refactoring.Model;

namespace RateMyAgent.Refactoring.Implementations
{
    public class TradeRecordParser : ITradeRecordParser
    {
        private readonly IRateMyAgentLogger _logger;
        // TODO: this can be an app setting
        private static float LotSize = 100000f;

        public TradeRecordParser(IRateMyAgentLogger logger)
        {
            _logger = logger;
        }

        public bool TryParse(string tradeRecord, int recordIndex, out TradeRecord parsedTadeRecord)
        {
            parsedTadeRecord = null;
            var fields = tradeRecord.Split(new char[] { ',' });

            if (fields.Length != 3)
            {
                _logger.Warn($"Line {recordIndex} malformed. Only {fields.Length} field(s) found.");
                return false;
            }

            if (fields[0].Length != 6)
            {
                _logger.Warn($"Trade currencies on line {0} malformed: [{fields[0]}]");
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                _logger.Warn($"Trade amount on line {0} is not a valid integer: [{fields[1]}]");
                return false;
            }
            else if (tradeAmount < 0)
            {
                _logger.Warn($"Trade amount on line {0} is a negative number: [{fields[1]}]");
                return false;
            }

            decimal tradePrice;
            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                _logger.Warn($"Trade price on line {0} is not a valid decimal: [{fields[1]}]");
                return false;
            }

            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);

            // Calculate values
            parsedTadeRecord = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };

            return true;
        }
    }
}
