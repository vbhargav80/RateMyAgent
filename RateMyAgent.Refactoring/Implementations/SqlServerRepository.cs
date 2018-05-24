using RateMyAgent.Refactoring.Abstractions;
using RateMyAgent.Refactoring.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyAgent.Refactoring.Implementations
{
    public class SqlServerRepository : IRepository
    {
        private readonly string _connectionString;

        public SqlServerRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TradesDb"].ConnectionString;
        }

        public void Save(List<TradeRecord> tradeRecords)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in tradeRecords)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                connection.Close();
            }
        }
    }
}
