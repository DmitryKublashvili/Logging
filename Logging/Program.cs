using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Logging
{
    /// <summary>
    /// Provides loggs of calculation.
    /// </summary>
    public interface ILogsProvider
    {
        void Provide(int result, int milliseconds);
    }

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

    public class LogsToFileProvider : ILogsProvider
    {
        public void Provide(int result, int milliseconds)
        {
            string filePath = @"Logs.csv";

            string log = $"Calculation result: ; {result} ; time of calculation ; {milliseconds}";

            File.AppendAllLines(filePath, new string[] { log });
        }
    }

    /// <summary>
    /// Provides templates for some algorithm calculation.
    /// </summary>
    public interface IAlgorithm
    {
        int Calculate(int first, int second);

        int Calculate(int first, int second, out int milliseconds);

        int Calculate(int first, int second, out int milliseconds, ILogsProvider provider);
    }

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

    static class Program
    {
        static void Main(string[] args)
        {
            Divider divider = new Divider();

            // simple dividing without time calculation and logging
            int result = divider.Calculate(25, 5);
            Console.WriteLine("result: " + result);

            // dividing with time calculation and without logging
            int milliseconds;
            result = divider.Calculate(int.MaxValue, 736954801, out milliseconds);
            Console.WriteLine("result: " + result + ", time: " + milliseconds);

            // dividing with time calculation and logging on console
            divider.Calculate(int.MaxValue, 736954801, out milliseconds, new LoggsToConsoleProvider());

            // dividing with time calculation and logging in file
            File.Delete(@"Logs.csv");

            divider.Calculate(int.MaxValue, 736954801, out milliseconds, new LogsToFileProvider());
            divider.Calculate(int.MaxValue, 7, out milliseconds, new LogsToFileProvider());
            divider.Calculate(int.MaxValue, -896543, out milliseconds, new LogsToFileProvider());

            var psi = new ProcessStartInfo
            {
                FileName = @"Logs.csv",
                UseShellExecute = true
            };

            Process.Start(psi);
        }
    }
}
