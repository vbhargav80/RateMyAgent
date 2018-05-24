using System;

namespace RateMyAgent.Refactoring.Abstractions
{
    public interface IRateMyAgentLogger
    {
        void Debug(string format, params object[] args);
        void Info(string format, params object[] args);
        void Warn(string format, params object[] args);
        void Error(Exception exception, string format, params object[] args);
    }
}
