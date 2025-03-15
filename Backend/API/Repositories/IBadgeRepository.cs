using API.Entities;

namespace API.Repositories;

public interface IBadgeRepository : IBaseRepository<Badge>
{
    Task<Badge?> GetByNameAsync(string badgeName);
    Task<List<Badge>> GetAllBadgesAsync();
}