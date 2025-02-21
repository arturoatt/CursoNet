
using Dapper;
using MinimalAPI.DataDapperLayer.ConnectionFactory;

namespace MinimalAPI.DataDapperLayer;

public class RepositoryDapper : IRepository
{
    private readonly IDbConnection _connection;
    private readonly ISqlConnectionFactory _factory;

    public RepositoryDapper(IDbConnection connection, ISqlConnectionFactory factory)
    {
        _connection = connection;
        _factory = factory;
    }


    public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
    {
        var query = "SELECT * FROM USUARIO";
        return await _connection.QueryAsync<Usuario>(query);
    }

    public async Task<IEnumerable<Usuario>> GetUsuariosFactoryAsync()
    {
        using var conexion = await _factory.CrearConexionAsync();  //{ }

        var query = "SELECT * FROM USUARIO";

        return await conexion.QueryAsync<Usuario>(query);
    }
}
