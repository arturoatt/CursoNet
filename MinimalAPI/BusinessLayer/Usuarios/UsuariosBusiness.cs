namespace MinimalAPI.BusinessLayer.Usuarios;

public class UsuariosBusiness : IUsuariosBusiness
{
    private readonly IUsuariosRepository _repository;

    public UsuariosBusiness(IUsuariosRepository repository)
    {
        _repository = repository;
    }

    public async Task AddUsuarioAsync(Usuario entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task DeleteUsuarioAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Usuario> GetUsuarioAsync(int id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<IEnumerable<Usuario>> GetUsuariosAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task UpdateUsuarioAsync(Usuario entity)
    {
        await _repository.UpdateAsync(entity);
    }
}
