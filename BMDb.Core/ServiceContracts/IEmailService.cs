namespace BMDb.Core.ServiceContracts;

public interface IEmailService
{
    Task SendAccessCodeAsync(string email, string code);
}