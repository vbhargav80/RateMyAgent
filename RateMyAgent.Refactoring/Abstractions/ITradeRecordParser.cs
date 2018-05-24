using RateMyAgent.Refactoring.Model;
using System;
namespace RateMyAgent.Refactoring.Abstractions
{
    public interface ITradeRecordParser
    {
        bool TryParse(string tradeRecord, int recordIndex, out TradeRecord parsedTadeRecord);
    }
}
