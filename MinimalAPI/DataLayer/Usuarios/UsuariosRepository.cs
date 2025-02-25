namespace MinimalAPI.DataLayer.Usuarios;

public class UsuariosRepository : IUsuariosRepository
{
    private readonly ApplicationDbContext _context;

    public UsuariosRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Usuario entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario entity)
    {
        _context.Usuarios.Attach(entity);

        _context.Entry(entity).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var u = await _context.Usuarios.FindAsync(id);
        _context.Remove(u);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetAsync(int id)
    {
        return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);
    }
}
