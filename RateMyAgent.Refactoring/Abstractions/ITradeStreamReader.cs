using System.Collections.Generic;

namespace RateMyAgent.Refactoring.Abstractions
{
    public interface ITradeStreamReader
    {
        List<string> ReadFromStream();
    }
}
