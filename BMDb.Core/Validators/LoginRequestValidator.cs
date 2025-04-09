using BMDb.Core.DTOs;
using FluentValidation;

namespace BMDb.Core.Validation;

/// <inheritdoc />
public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    /// <inheritdoc />
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}