using Microsoft.EntityFrameworkCore;
using API.Entities;
using System.Web;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Repositories.Implementation;

public class UserRepository(PostgresDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<bool> CheckIfUsernameExistsAsync(string username)
    {
        return await context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> CheckIfEmailExistsAsync(string email)
    {
        return await context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.RefreshToken == HttpUtility.UrlDecode(refreshToken));
    }
}