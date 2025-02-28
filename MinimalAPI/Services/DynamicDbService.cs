using System.Text.Json;

namespace MinimalAPI.Services;

public class DynamicDbService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly HttpClient _httpClient = new HttpClient();
    private DatabaseSettings _settings;
    private IConfiguration _config;

    public DynamicDbService(IServiceProvider serviceProvider, IConfiguration config) => (_serviceProvider, _config) = (serviceProvider, config);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await UpdateDatabaseSettings();
            var nextUpdate = GetNextSwitchTime();

            await Task.Delay(nextUpdate - DateTime.Now, stoppingToken);
        }
    }

    private async Task UpdateDatabaseSettings()
    {
        var response = await _httpClient.GetStringAsync(_config.GetConnectionString("DefaultConnection"));
        _settings = JsonSerializer.Deserialize<DatabaseSettings>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        using var scope = _serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        //este es para Dapper
        services.GetRequiredService<IDbConnection>().ConnectionString = _settings.ConnectionString;
        //este es para EF
        services.GetRequiredService<ApplicationDbContext>().Dispose();
        services.GetRequiredService<ApplicationDbContext>().Database.SetDbConnection(new SqlConnection(_settings.ConnectionString));


    }

    private DateTime GetNextSwitchTime()
    {
        var today = DateTime.Today;
        var switchTime = TimeSpan.Parse(_settings.SwitchTime);
        var nextSwitch = today.Add(switchTime);

        return nextSwitch < DateTime.Now ? nextSwitch.AddDays(1) : nextSwitch;
    }
}