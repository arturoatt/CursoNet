namespace MinimalAPI.BasicAuthServices;

internal class BasicAuthService : IBasicAuthService
{
    private readonly HttpContext _context;
    private readonly Microsoft.Extensions.Logging.ILogger _logger;

    public BasicAuthService(IHttpContextAccessor context, ILogger<BasicAuthService> logger)
        => (_context, _logger) = (context.HttpContext!, logger);

    public async Task<string> GetUserName()
    {
        // Obtener el encabezado Authorization
        if (!_context.Request.Headers.TryGetValue("Authorization", out var authHeader))
            throw new UnauthorizedAccessException("Verifique su información");

        // Decodificar las credenciales del encabezado Authorization (Basic Auth)
        var credentials = GetCredentialsFromHeader(authHeader);

        if (!await ValidarUsuarioAsync(credentials.username, credentials.password))
            throw new UnauthorizedAccessException("Verifique su información");

        return credentials.username;
    }

    private static (string username, string password) GetCredentialsFromHeader(string authHeader)
    {
        if (!authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
            throw new UnauthorizedAccessException("Verifique su información");

        var encodedCredentials = authHeader["Basic ".Length..].Trim();
        var credentialBytes = Convert.FromBase64String(encodedCredentials);
        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');

        if (credentials.Length != 2)
        {
            throw new UnauthorizedAccessException("Verifique su información");
        }

        return (credentials[0], credentials[1]);
    }

    // Método para validar las credenciales del usuario
    private Task<bool> ValidarUsuarioAsync(string username, string pass)
    {
        //Se los dejo como un ejemplo con Dapper
        //using var _dapper = await _factory.CrearConexionAsync();

        //var parametros = new DynamicParameters();
        //parametros.Add(Constantes.Pacjson, JsonSerializer.Serialize(new { usuario = username, password = pass, API = new { id = _apiId } }), DbType.String);

        //var ok = await _dapper.QueryFirstOrDefaultAsync<int>(Constantes.SpValidaUSuario, parametros, commandType: CommandType.StoredProcedure);

        //if (ok != 1)
        //{
        //    string clientIp = _context.Connection.RemoteIpAddress?.ToString() ?? "IP desconocida";
        //    _logger.LogCritical("ID:{TraceIdentifier} IP:{ClientIp} API:{Api} MENSAJE:{Message}",
        //                        _context.TraceIdentifier, clientIp,
        //                        _context.Request.Path, $"Intento fallido del usuario {username}");

        //    throw new UnauthorizedAccessException("Acceso no autorizado");
        //}

        return Task.FromResult(true);
    }
}
