using RateMyAgent.Refactoring.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateMyAgent.Refactoring.Implementations
{
    public class HardcodedTradeStreamReader : ITradeStreamReader
    {
        public List<string> ReadFromStream()
        {
            var stream = GetDummyStream();
            var lines = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }

        private Stream GetDummyStream()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            writer.Write($"AUDUSD,30,15.6{Environment.NewLine}AUDUSD,40,22{Environment.NewLine}AUDNZD,50,22.9");
            writer.Flush();

            stream.Position = 0;
            return stream;
        }
    }
}
