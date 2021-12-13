namespace Logging
{
    /// <summary>
    /// Provides templates for some algorithm calculation.
    /// </summary>
    public interface IAlgorithm
    {
        int Calculate(int first, int second);

        int Calculate(int first, int second, out int milliseconds);

        int Calculate(int first, int second, out int milliseconds, ILogsProvider provider);
    }
}
