using Serilog;
using Serilog.Events;

namespace MinimalAPI.Logger;

public static class DependencyInjection
{
    public static IServiceCollection AddLoggerServices(this IServiceCollection services, IConfiguration config)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Settings(new LoggerSettings(config))
        // Archivos filtrados por nivel 
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Verbose)
            .WriteTo.File($"\\verbose-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
            .WriteTo.File($"\\debug-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
            .WriteTo.File($"\\information-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
            .WriteTo.File($"\\warning-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
            .WriteTo.File($"\\error-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
            .WriteTo.File($"\\fatal-.txt", rollingInterval: RollingInterval.Day))
        //.WriteTo.Logger(lc => lc
        //    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
        //    .WriteTo.MSSqlServer()
        .CreateLogger();

        return services;
    }
}
