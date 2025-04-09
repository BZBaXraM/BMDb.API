using BMDb.Core.DTOs;
using FluentValidation;

namespace BMDb.Core.Validation;

/// <summary>
///   This class is used to validate the RegisterRequestDto.
/// </summary>
public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    /// <summary>
    ///  This constructor is used to validate the RegisterRequestDto.
    /// </summary>
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).Password(mustContainDigit: false);
    }
}