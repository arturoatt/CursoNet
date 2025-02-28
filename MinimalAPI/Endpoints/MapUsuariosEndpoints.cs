

using Microsoft.AspNetCore.Authorization;

namespace MinimalAPI.Endpoints;

public static class UsuariosEndpoints
{
    public static IEndpointRouteBuilder MapUsuarios(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", [AllowAnonymous] async (ApplicationDbContext _context, IMapper _mapper) => _mapper.Map<IEnumerable<UsuarioDTO>>(await _context.Usuarios.ToListAsync()));
        //{
        //return await _context.Usuarios.ToListAsync();
        //return _mapper.Map<IEnumerable<UsuarioDTO>>(await _context.Usuarios.ToListAsync());
        //});

        app.MapGet("/{id:int}", GetUsuarioID).AllowAnonymous();

        app.MapPut("/{id:int}", UpdateUsuario);

        app.MapPost("/", AddUsuario).AddEndpointFilter<MyValidatorFilter<UsuarioDTO>>().RequireAuthorization("administradores"); ;

        app.MapDelete("/{id}", DeleteUsuario);

        return app;
    }

    private static async Task<IResult> GetUsuarioID(int id, ApplicationDbContext _context, IMapper _mapper)
    {
        //var usuario = await _context.Usuarios.FindAsync(id);
        var usuario = _mapper.Map<UsuarioDTO>(await _context.Usuarios.FindAsync(id));
        return usuario is not null ? Results.Ok(usuario) : Results.NotFound(new { mensaje = "Usuario no encontrado" });
    }

    private static async Task<IResult> UpdateUsuario(int id, UsuarioDTO dto, IUsuariosRepository _repository, IMapper _mapper)
    {
        var o = _mapper.Map<Usuario>(dto);
        await _repository.UpdateAsync(o);

        return Results.Ok(dto);
    }

    private static async Task<IResult> AddUsuario(UsuarioDTO dto, IUsuariosBusiness _business, IMapper _mapper)
    {
        var o = _mapper.Map<Usuario>(dto);
        await _business.AddUsuarioAsync(o);

        return Results.Created($"/{o.UsuarioId}", dto);
    }
    private static async Task<IResult> DeleteUsuario(int id, IUsuariosBusiness _business)
    {
        await _business.DeleteUsuarioAsync(id);

        return Results.NoContent();
    }
}
