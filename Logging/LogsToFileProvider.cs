using System.IO;

namespace Logging
{
    public class LogsToFileProvider : ILogsProvider
    {
        public void Provide(int result, int milliseconds)
        {
            string filePath = @"Logs.csv";

            string log = $"Calculation result: ; {result} ; time of calculation ; {milliseconds}";

            File.AppendAllLines(filePath, new string[] { log });
        }
    }
}
