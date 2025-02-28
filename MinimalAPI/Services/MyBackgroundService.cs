namespace MinimalAPI.Services;

public class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine($"Servicio en ejecución: {DateTime.Now}");
            await Task.Delay(5000, stoppingToken); // Espera 5 segundos
        }
    }
    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Servicio detenido correctamente.");
        await base.StopAsync(cancellationToken);
    }
}
