namespace MinimalAPI.BusinessLayer.Usuarios;

public interface IUsuariosBusiness
{
    Task AddUsuarioAsync(Usuario entity);
    Task DeleteUsuarioAsync(int id);
    Task<IEnumerable<Usuario>> GetUsuariosAllAsync();
    Task<Usuario> GetUsuarioAsync(int id);
    Task UpdateUsuarioAsync(Usuario entity);
}
