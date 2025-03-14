using API.Entities;

namespace API.Repositories.Implementation;

public class CourseRepository(PostgresDbContext context) : BaseRepository<Course>(context), ICourseRepository
{
    
}