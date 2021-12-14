namespace Logging
{
    /// <summary>
    /// Provides loggs of calculation.
    /// </summary>
    public interface ILogsProvider
    {
        void Provide(string message);
    }
}
