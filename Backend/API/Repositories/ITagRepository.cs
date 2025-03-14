using API.Entities;

namespace API.Repositories;

public interface ITagRepository : IBaseRepository<Tag>
{
    Task<Tag?> GetByNameAsync(string tagName);
}