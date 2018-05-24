using RateMyAgent.Refactoring.Abstractions;
using RateMyAgent.Refactoring.Implementations;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyAgent.Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var serilogLogger = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            IRateMyAgentLogger logger = new RateMyAgentLogger(serilogLogger);
            IRepository repository = new SqlServerRepository();
            ITradeRecordParser parser = new TradeRecordParser(logger);
            ITradeStreamReader reader = new HardcodedTradeStreamReader();

            ITradeProcessor processor = new TradeProcessor(logger, repository, parser, reader);
            processor.ProcessTrades();
        }
    }
}
