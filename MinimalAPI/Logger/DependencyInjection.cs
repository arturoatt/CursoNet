using Serilog.Events;

namespace MinimalAPI.Logger;

public static class DependencyInjection
{
    public static IServiceCollection AddLoggerServices(this IServiceCollection services, IConfiguration config)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Settings(new LoggerSettings(config))
            .WriteTo.Console()
        // Archivos filtrados por nivel 
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Verbose)
            .WriteTo.File($"{AppContext.BaseDirectory}/logs/verbose-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug)
            .WriteTo.File($"{AppContext.BaseDirectory}/logs/debug-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information)
            .WriteTo.File($"{AppContext.BaseDirectory}/logs/information-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning)
            .WriteTo.File($"{AppContext.BaseDirectory}/logs/warning-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error)
            .WriteTo.File($"{AppContext.BaseDirectory}/logs/error-.txt", rollingInterval: RollingInterval.Day))
        .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
            .WriteTo.File($"{AppContext.BaseDirectory}/logs/fatal-.txt", rollingInterval: RollingInterval.Day))
        //.WriteTo.Logger(lc => lc
        //    .Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal)
        //    .WriteTo.MSSqlServer()
        .CreateLogger();

        return services;
    }
}
