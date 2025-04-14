namespace BMDb.Core.Validators;

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
    }
}