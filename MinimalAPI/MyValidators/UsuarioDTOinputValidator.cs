namespace MinimalAPI.MyValidators;

public class UsuarioDTOinputValidator : AbstractValidator<UsuarioDTO>
{
    public UsuarioDTOinputValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotNull().NotEmpty().NoTieneCarateresEspeciales();
    }
}