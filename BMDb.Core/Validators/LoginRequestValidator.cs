namespace BMDb.Core.Validators;

/// <inheritdoc />
public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    /// <inheritdoc />
    public LoginRequestValidator()
    {
        RuleFor(x => x.AccessCode).NotEmpty();
    }
}