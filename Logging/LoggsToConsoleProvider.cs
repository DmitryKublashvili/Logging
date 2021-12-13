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
        public void Provide(int result, int milliseconds)
        {
            Console.WriteLine("Calculation result: {0}, time of calculation {1}", result, milliseconds);
        }
    }
}
