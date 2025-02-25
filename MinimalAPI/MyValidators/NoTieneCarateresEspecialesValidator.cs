namespace MinimalAPI.MyValidators;

public class NoTieneCarateresEspecialesValidator<T, TProperty> : PropertyValidator<T, TProperty>
{
    public override string Name => "NoTieneCarateresEspecialesValidator";
    public NoTieneCarateresEspecialesValidator()
    {

    }
    public override bool IsValid(ValidationContext<T> context, TProperty value)
    {

        return !Regex.IsMatch(value.ToString().Trim(), @"[^\w\ .,@-]");
    }

    protected override string GetDefaultMessageTemplate(string errorCode) => "{PropertyName} No debe tener carácteres especiales.";
}
