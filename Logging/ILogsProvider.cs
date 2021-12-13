namespace Logging
{
    /// <summary>
    /// Provides loggs of calculation.
    /// </summary>
    public interface ILogsProvider
    {
        void Provide(int result, int milliseconds);
    }
}
