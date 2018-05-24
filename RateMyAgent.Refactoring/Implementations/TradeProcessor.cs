using RateMyAgent.Refactoring.Abstractions;
using RateMyAgent.Refactoring.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace RateMyAgent.Refactoring.Implementations
{
    public class TradeProcessor : ITradeProcessor
    {
        private readonly IRateMyAgentLogger _logger;
        private readonly IRepository _repository;
        private readonly ITradeRecordParser _parser;
        private readonly ITradeStreamReader _streamReader;

        public TradeProcessor(
            IRateMyAgentLogger logger, 
            IRepository repository, 
            ITradeRecordParser parser,
            ITradeStreamReader streamReader
            )
        {
            _logger = logger;
            _repository = repository;
            _parser = parser;
            _streamReader = streamReader;
        }

        public void ProcessTrades()
        {
            var lines = _streamReader.ReadFromStream();
            var trades = new List<TradeRecord>();

            for (int i = 0; i < lines.Count; i++)
            {
                TradeRecord tradeRecord;

                if (_parser.TryParse(lines[i], i, out tradeRecord))
                {
                    trades.Add(tradeRecord);
                }
            }

            // The database is not setup so thsi will throw an exception, I'm catching and logging it
            // With time, I would have created the db
            try
            {
                _repository.Save(trades);
                _logger.Info($"{trades.Count} trades processed");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error when writing to the database.");
            }
        }
    }
}
