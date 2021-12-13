using System;
using System.Diagnostics;
using System.IO;

namespace Logging
{
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
