using Microsoft.AspNetCore.Authentication.JwtBearer;
using MinimalAPI.JWT;
using MinimalAPI.JWT.JwtServices;
using System.Text.Json;

public static class DependencyInjection
{
    private static readonly string config = "MySettings.json";
    public static IServiceCollection AddJwtServices(this IServiceCollection services)
    {
        var miconfig = new ConfigurationBuilder().AddJsonFile(config, false, true).Build();


        services.Configure<MiConfiguracion>(opciones =>
        {
            opciones.SecretKey = miconfig.GetValue<string>("JwtToken:SecretKey")!;
        });

        services.AddScoped<IBasicAuthService, BasicAuthService>();
        services.AddScoped<IJwtService, JwtService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opciones =>
                {
                    opciones.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = true,
                        ValidAudience = "urls;claves;",
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(miconfig.GetValue<string>("JwtToken:SecretKey")!)),
                        ClockSkew = TimeSpan.Zero
                    };
                    opciones.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger<Microsoft.Extensions.Logging.ILogger>();
                            logger.LogCritical(context.Exception.Message);

                            return Task.CompletedTask;
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();

                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            var result = JsonSerializer.Serialize(new
                            {
                                mensaje = "Acceso al recurso no autorizado"
                            });
                            return context.Response.WriteAsync(result);
                        }
                    };
                });

        services.AddAuthorization(opciones =>
        {
            opciones.AddPolicy("administradores", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
        });

        return services;
    }
}