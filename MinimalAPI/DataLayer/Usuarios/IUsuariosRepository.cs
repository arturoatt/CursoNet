namespace MinimalAPI.DataLayer.Usuarios;

public interface IUsuariosRepository
{
    Task AddAsync(Usuario entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetAsync(int id);
    Task UpdateAsync(Usuario entity);
}