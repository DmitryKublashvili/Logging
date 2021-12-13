using System;
using System.Diagnostics;
using System.Threading;

namespace Logging
{
    public class Divider : IAlgorithm
    {
        /// <summary>
        /// Divid two integers.
        /// </summary>
        /// <param name="first">Divisible.</param>
        /// <param name="second">Divider.</param>
        /// <returns>Integer result of dividing.</returns>
        public int Calculate(int first, int second) => first / second;

        /// <summary>
        /// Divid two integers.
        /// </summary>
        /// <param name="first">Divisible.</param>
        /// <param name="second">Divider.</param>
        /// <param name="milliseconds">time of calculation.</param>
        /// <returns>Integer result of dividing.</returns>
        public int Calculate(int first, int second, out int milliseconds)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            // simulation of time calculation
            Thread.Sleep(new Random().Next(300, 500));

            int result = first / second;

            stopwatch.Stop();

            milliseconds = (int)stopwatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Divid two integers.
        /// </summary>
        /// <param name="first">Divisible.</param>
        /// <param name="second">Divider.</param>
        /// <param name="milliseconds">time of calculation.</param>
        /// <param name="provider">Provider for logging.</param>
        /// <returns>Integer result of dividing.</returns>
        public int Calculate(int first, int second, out int milliseconds, ILogsProvider provider)
        {
            int result = Calculate(first, second, out milliseconds);

            provider.Provide(second, milliseconds);

            return result;
        }
    }
}
