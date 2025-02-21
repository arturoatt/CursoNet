using MinimalAPI.DataLayer;

namespace MinimalAPI.Endpoints;

public static class WeatherforecastEndPoints
{

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {


        app.MapGet("/weatherforecast", (IBusiness _ibusiness, ILogger<Program> logger) =>
        {
            logger.LogInformation("Hola estoy weatherforecast");
            return _ibusiness.Getweatherforecast();
        });

        app.MapGet("/GetUsuarios", (ApplicationDbContext context) =>
        {
            return context.Usuarios.ToList();
        });

        app.MapGet("/GetRoles", (ApplicationDbContext context) =>
        {
            return context.Roles.ToList();
        });


        return app;
    }
}
