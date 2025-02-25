using MinimalAPI.Exceptions;

namespace MinimalAPI.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        => (_next, _logger) = (next, logger);

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {

            await _next(context);

        }
        catch (BadRequestException ex)
        {

            await Results.BadRequest(ex.Message).ExecuteAsync(context);
        }
        catch (NotFoundException ex)
        {

            await Results.NotFound(ex.Message).ExecuteAsync(context);
        }
        catch (ConflictException ex)
        {

            await Results.Conflict(ex.Message).ExecuteAsync(context);
        }
        catch (SqlException)
        {

            await Results.Json("El servicio de sql no esta disponible por el momento, intente mas tarde.", statusCode: 503).ExecuteAsync(context);
        }
        catch (Exception)
        {
            await Results.Json("El servicio no esta disponible por el momento, intente mas tarde.", statusCode: 503).ExecuteAsync(context);
        }
    }
}

