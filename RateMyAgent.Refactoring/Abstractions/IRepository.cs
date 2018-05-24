using RateMyAgent.Refactoring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyAgent.Refactoring.Abstractions
{
    public interface IRepository
    {
        void Save(List<TradeRecord> tradeRecords);
    }
}
