using API.Entities;

namespace API.Repositories.Implementation;

public class LearningCourseRepository(PostgresDbContext context) : BaseRepository<LearningCourse>(context), ILearningCourseRepository
{
    
}