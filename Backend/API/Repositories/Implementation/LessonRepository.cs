using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementation;

public class LessonRepository(PostgresDbContext context) : BaseRepository<Lesson>(context), ILessonRepository
{
    public async Task<Lesson?> GetByTitleAsync(string lessonTitle)
    {
        return await context.Set<Lesson>().FirstOrDefaultAsync(x => x.Title.ToLower().Equals(lessonTitle.ToLower()));
    }
}