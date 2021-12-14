using System.IO;

namespace Logging
{
    public class LogsToFileProvider : ILogsProvider
    {
        public void Provide(string message)
        {
            string filePath = @"Logs.txt";

            File.AppendAllLines(filePath, new string[] { message });
        }
    }
}
