namespace BMDb.Core.Validators;

/// <inheritdoc />
public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    /// <inheritdoc />
    public LoginRequestValidator()
    {
        RuleFor(x => x.AccessCode).NotEmpty();
    }
}