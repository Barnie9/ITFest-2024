using API.Repositories;
using API.Repositories.Implementation;

namespace API.SetupExtensions;

public static class AddRepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<ICourseRepository, CourseRepository>()
            .AddTransient<ITagRepository, TagRepository>()
            .AddTransient<ILessonRepository, LessonRepository>()
            .AddTransient<IBadgeRepository, BadgeRepository>();
}