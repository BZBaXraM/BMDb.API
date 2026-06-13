namespace BMDb.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MovieContext _context;

    public UserRepository(MovieContext context)
    {
        _context = context;
    }

    public async Task<User> AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> GetAccessCodeAsync(string accessCode)
    {
        return (await _context.Users
            .FirstOrDefaultAsync(u => u.AccessCode == accessCode))!;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        return (await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email))!;
    }

    public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
    {
        return (await _context.Users
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken))!;
    }

    public async Task<User?> GetUserDataAsync(string accessToken, string? userName)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.AccessCode == accessToken || u.AccessCode == userName);
    }

    public async Task<int> SaveUserAsync()
    {
        return await _context.SaveChangesAsync();
    }
}