
using NLog;
using Services.Contracts;

namespace Services;

public class LoggerManager : ILoggerService
{
    private static ILogger Logger = LogManager.GetCurrentClassLogger();
    public void LogInfo(string message)=> Logger.Info(message);

    public void LogWarning(string message) => Logger.Warn(message);

    public void LogError(string message) => Logger.Error(message);

    public void LogDebug(string message) => Logger.Debug(message);
}