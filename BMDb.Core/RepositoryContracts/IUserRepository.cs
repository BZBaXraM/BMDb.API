namespace BMDb.Core.RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<User> GetAccessCodeAsync(string accessCode);
    Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    Task<User> UpdateUserAsync(User user);
}