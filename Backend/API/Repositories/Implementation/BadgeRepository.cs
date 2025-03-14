using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation;

public class BadgeRepository(PostgresDbContext context) : BaseRepository<Badge>(context), IBadgeRepository
{
    public async Task<Badge?> GetByNameAsync(string badgeName)
    {
        return await context.Set<Badge>().FirstOrDefaultAsync(x => x.Name.ToLower().Equals(badgeName.ToLower()));
    }
}