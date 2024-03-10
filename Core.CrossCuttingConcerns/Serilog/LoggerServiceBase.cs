
using Serilog;

namespace Core.CrossCuttingConcerns.Serilog;
public abstract class LoggerServiceBase
{
    protected ILogger Logger { get; set; }
    protected LoggerServiceBase() => Logger = null;
    protected LoggerServiceBase(ILogger logger) => Logger = logger;

    protected void Verbose(string message) => Logger.Verbose(message);
    protected void Fatal(string message) => Logger.Fatal(message);
    protected void Info(string message) => Logger.Information(message);
    protected void Warn(string message) => Logger.Warning(message);
    protected void Debug(string message) => Logger.Debug(message);
    protected void Error(string message) => Logger.Error(message);

}
