using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation;

public class BadgeRepository(PostgresDbContext context) : BaseRepository<Badge>(context), IBadgeRepository
{
    public async Task<Badge?> GetByNameAsync(string badgeName) =>
        await context.Set<Badge>().FirstOrDefaultAsync(x => x.Name.ToLower().Equals(badgeName.ToLower()));

    public async Task<List<Badge>> GetAllBadgesAsync() =>
        await context.Set<Badge>().ToListAsync();
}