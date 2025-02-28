using MinimalAPI.JWT.JwtServices;

namespace MinimalAPI;

public static class JwtEndpoints
{
    public static IEndpointRouteBuilder MapJwtEndpoints(this IEndpointRouteBuilder app)
    {
        // Endpoint de login para obtener un JWT        
        app.MapPost("/logging", Token);

        return app;
    }

    private static async Task<IResult> Token(IBasicAuthService basicAuthService, IJwtService jwtService)
    {
        var credentials = await basicAuthService.GetUserName();

        // Generar JWT si las credenciales son correctas
        return Results.Ok(new { Token = jwtService.GeneraToken(credentials) });
    }
}
