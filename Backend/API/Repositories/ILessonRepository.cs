using API.Entities;

namespace API.Repositories;

public interface ILessonRepository : IBaseRepository<Lesson>
{
    Task<Lesson?> GetByTitleAsync(string lessonTitle);
}