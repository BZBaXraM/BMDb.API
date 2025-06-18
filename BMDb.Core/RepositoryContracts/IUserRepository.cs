namespace BMDb.Core.RepositoryContracts;

public interface IUserRepository
{
    Task<User> AddUserAsync(User user);
    Task<User> GetAccessCodeAsync(string accessCode);
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    Task<User> GetUserDataAsync(string accessToken, string? userName);
    Task<int> SaveUserAsync();
}