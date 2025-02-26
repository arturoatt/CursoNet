using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace MinimalAPI.Logger;
internal class LoggerSettings : ILoggerSettings
{
    private readonly IConfiguration _conf;
    public LoggerSettings(IConfiguration conf) => _conf = conf;

    public void Configure(LoggerConfiguration loggerConfiguration)
    {
        loggerConfiguration.MinimumLevel.Is(Enum.Parse<LogEventLevel>(_conf["Logging:LogLevel:Default"]));
    }
}
