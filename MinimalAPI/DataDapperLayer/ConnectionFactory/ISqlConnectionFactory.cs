namespace MinimalAPI.DataDapperLayer.ConnectionFactory;

public interface ISqlConnectionFactory
{
    IDbConnection CrearConexion();
    Task<IDbConnection> CrearConexionAsync();
}
