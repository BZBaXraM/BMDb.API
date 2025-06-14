namespace BMDb.Core.RepositoryContracts;

public interface IUserService
{
    Task<UserDto> GetAccessCodeAsync(string accessCode);
}