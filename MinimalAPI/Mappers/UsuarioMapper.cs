namespace MinimalAPI.Mappers;

public class UsuarioMapper : Profile
{
    public UsuarioMapper()
    {
        CreateMap<Usuario, UsuarioDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UsuarioId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
            .ReverseMap();
    }
}
