namespace MinimalAPI.MyValidators;

public class UsuarioDTOinputValidator : AbstractValidator<Usuario>
{
    public UsuarioDTOinputValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.UsuarioId).GreaterThan(0);
        RuleFor(x => x.Nombre).NotEmpty().NoTieneCarateresEspeciales();
    }
}