using RateMyAgent.Refactoring.Abstractions;
using Serilog;
using System;

namespace RateMyAgent.Refactoring.Implementations
{
    public class RateMyAgentLogger : IRateMyAgentLogger
    {
        private readonly ILogger _logger;

        public RateMyAgentLogger(ILogger logger)
        {
            _logger = logger;
        }

        public void Debug(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public void Error(Exception exception, string format, params object[] args)
        {
            _logger.Error(exception, format, args);
        }

        public void Info(string format, params object[] args)
        {
            _logger.Information(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            _logger.Warning(format, args);
        }
    }
}
