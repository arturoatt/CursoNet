namespace MinimalAPI.DataDapperLayer.ConnectionFactory;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _conexionString;

    public SqlConnectionFactory(string conexionString)
    {
        _conexionString = conexionString;
    }

    public IDbConnection CrearConexion()
    {
        var conexion = new SqlConnection(_conexionString);
        conexion.Open();

        return conexion;
    }

    public async Task<IDbConnection> CrearConexionAsync()
    {
        var conexion = new SqlConnection(_conexionString);
        await conexion.OpenAsync();

        return conexion;
    }
}
