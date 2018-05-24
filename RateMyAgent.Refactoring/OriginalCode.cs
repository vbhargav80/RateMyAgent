using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyAgent.Refactoring
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace RefactorExercise
    {
        //public class TradeProcessor
        //{
        //    private static float LotSize = 100000f;

        //    public void ProcessTrades(Stream stream)
        //    {

        //        var lines = new List<string>();
        //        using (var reader = new StreamReader(stream))
        //        {
        //            string line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                lines.Add(line);
        //            }
        //        }

        //        var trades = new List<TradeRecord>();
        //        var lineCount = 1;
        //        foreach (var line in lines)
        //        {
        //            var fields = line.Split(new char[] { ',' });

        //            if (fields.Length != 3)
        //            {
        //                Console.WriteLine($"WARN: Line {lineCount} malformed. Only {fields.Length} field(s) found.");
        //                continue;
        //            }

        //            if (fields[0].Length != 6)
        //            {
        //                Console.WriteLine($"WARN: Trade currencies on line {0} malformed: [{fields[0]}]");
        //                continue;
        //            }

        //            int tradeAmount;
        //            if (!int.TryParse(fields[1], out tradeAmount))
        //            {
        //                Console.WriteLine($"WARN: Trade amount on line {0} is not a valid integer: [{fields[1]}]");
        //                continue;
        //            }

        //            decimal tradePrice;
        //            if (!decimal.TryParse(fields[2], out tradePrice))
        //            {
        //                Console.WriteLine($"WARN: Trade price on line {0} is not a valid decimal: [{fields[1]}]");
        //                continue;
        //            }

        //            var sourceCurrencyCode = fields[0].Substring(0, 3);
        //            var destinationCurrencyCode = fields[0].Substring(3, 3);

        //            // Calculate values
        //            var trade = new TradeRecord
        //            {
        //                SourceCurrency = sourceCurrencyCode,
        //                DestinationCurrency = destinationCurrencyCode,
        //                Lots = tradeAmount / LotSize,
        //                Price = tradePrice
        //            };

        //            trades.Add(trade);

        //            lineCount++;
        //        }

        //        using (var connection = new SqlConnection("Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True"))
        //        {
        //            connection.Open();
        //            using (var transaction = connection.BeginTransaction())
        //            {
        //                foreach (var trade in trades)
        //                {
        //                    var command = connection.CreateCommand();
        //                    command.Transaction = transaction;
        //                    command.CommandType = CommandType.StoredProcedure;
        //                    command.CommandText = "dbo.insert_trade";
        //                    command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
        //                    command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
        //                    command.Parameters.AddWithValue("@lots", trade.Lots);
        //                    command.Parameters.AddWithValue("@price", trade.Price);

        //                    command.ExecuteNonQuery();
        //                }

        //                transaction.Commit();
        //            }
        //            connection.Close();
        //        }

        //        Console.WriteLine($"INFO: {trades.Count} trades processed");
        //    }
        //}
    }
}
