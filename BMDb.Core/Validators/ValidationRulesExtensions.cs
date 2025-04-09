using System.Text.RegularExpressions;
using FluentValidation;

namespace BMDb.Core.Validation;


/// <summary>
///  This class is used to extend the FluentValidation IRuleBuilder interface.
/// </summary>
public static class ValidationRulesExtensions
{
    /// <summary>
    /// This method is used to validate the password.
    /// </summary>
    /// <param name="ruleBuilder"></param>
    /// <param name="mustContainLowercase"></param>
    /// <param name="mustContainUppercase"></param>
    /// <param name="mustContainDigit"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> Password<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool mustContainLowercase = true,
        bool mustContainUppercase = true,
        bool mustContainDigit = true)
    {
        IRuleBuilderOptions<T, string>? options = null;

        if (mustContainUppercase)
        {
            options = ruleBuilder.Must(pass => new Regex("[A-Z]").IsMatch(pass))
                .WithMessage("Password must contain at least 1 uppercase letter");
        }

        if (mustContainLowercase)
        {
            options = ruleBuilder.Must(pass => new Regex("[a-z]").IsMatch(pass))
                .WithMessage("Password must contain at least 1 lowercase letter");
        }

        if (mustContainDigit)
        {
            options = ruleBuilder.Must(pass => new Regex("[0-9]").IsMatch(pass))
                .WithMessage("Password must contain at least 1 number");
        }

        return options!;
    }
}