namespace MinimalAPI.MyValidators;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, TProperty> NoTieneCarateresEspeciales<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
    {
        return ruleBuilder.SetValidator(new NoTieneCarateresEspecialesValidator<T, TProperty>());
    }
}
