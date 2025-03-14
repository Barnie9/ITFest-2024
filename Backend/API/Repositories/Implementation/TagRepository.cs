using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation;

public class TagRepository(PostgresDbContext context) : BaseRepository<Tag>(context), ITagRepository
{
    public async Task<Tag?> GetByNameAsync(string tagName)
    {
        return await context.Set<Tag>().FirstOrDefaultAsync(x => x.Name.ToLower().Equals(tagName.ToLower()));
    }
}