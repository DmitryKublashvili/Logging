using System;

namespace Logging
{
    public class LoggsToConsoleProvider : ILogsProvider
    {
        /// <summary>
        /// Print result and calculation time on console.
        /// </summary>
        /// <param name="result"></param>
        /// <param name="milliseconds"></param>
        public void Provide(string message)
        {
            Console.WriteLine(message);
        }
    }
}
