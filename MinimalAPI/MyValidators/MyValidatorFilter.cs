namespace MinimalAPI.MyValidators;

public class MyValidatorFilter<T> : IEndpointFilter where T : class
{
    private readonly IValidator<T> _validator;

    public MyValidatorFilter(IValidator<T> validator) => _validator = validator;

    public async ValueTask<object> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {

        var argument = context.Arguments.FirstOrDefault();

        if (argument is T model)
        {
            ValidationResult result = await _validator.ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new Exception(result.ToString());
                //throw new BadRequestException(result.ToString());
            }
        }

        // Continuar con la siguiente parte del pipeline
        return await next(context);
    }
}
