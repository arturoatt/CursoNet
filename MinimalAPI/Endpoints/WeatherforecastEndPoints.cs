﻿namespace MinimalAPI.Endpoints;

public static class WeatherforecastEndPoints
{

    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
    {


        app.MapGet("/weatherforecast", (IBusiness _ibusiness, ILogger<Program> logger) =>
        {
            logger.LogInformation("Hola estoy weatherforecast");
            return _ibusiness.Getweatherforecast();
        });
        app.MapGet("/stop", (IHostApplicationLifetime lifetime) =>
        {
            Task.Run(() => lifetime.StopApplication());
            return "La aplicación se está deteniendo...";
        });
        //app.MapGet("/GetUsuarios", (ApplicationDbContext context) =>
        //{
        //    return context.Usuarios.ToList();
        //});

        //app.MapGet("/GetRoles", (ApplicationDbContext context) =>
        //{
        //    return context.Roles.ToList();
        //});

        //app.MapPost("/AddUsuario", (ApplicationDbContext context, Usuario dto) =>
        //{
        //    context.Usuarios.Add(dto);

        //    //context.Roles.Add(dto.Roles);
        //    //context.Usuarios.Update(dto);


        //    context.SaveChanges();

        //});
        return app;
    }
}
