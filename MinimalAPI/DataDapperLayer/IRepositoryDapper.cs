namespace MinimalAPI.DataDapperLayer;

public interface IRepositoryDapper
{
    Task<IEnumerable<Usuario>> GetUsuariosAsync();
    Task<IEnumerable<Usuario>> GetUsuariosFactoryAsync();
}
