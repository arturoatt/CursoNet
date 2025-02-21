namespace MinimalAPI.DataDapperLayer;

public interface IRepository
{
    Task<IEnumerable<Usuario>> GetUsuariosAsync();
    Task<IEnumerable<Usuario>> GetUsuariosFactoryAsync();
}
