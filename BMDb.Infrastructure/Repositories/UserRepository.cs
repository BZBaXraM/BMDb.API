namespace BMDb.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthContext _authContext;

    public UserRepository(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public async Task<User> AddUserAsync(User user)
    {
        await _authContext.Users.AddAsync(user);
        await _authContext.SaveChangesAsync();
        return user;
    }

    public async Task<User> GetAccessCodeAsync(string accessCode)
    {
        return (await _authContext.Users
            .FirstOrDefaultAsync(u => u.AccessCode == accessCode))!;
    }

    public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
    {
        return (await _authContext.Users
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken))!;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        _authContext.Users.Update(user);
        await _authContext.SaveChangesAsync();
        return user;
    }
}