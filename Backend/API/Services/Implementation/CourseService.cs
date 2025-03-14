using API.Entities;
using API.Models;
using API.Repositories;

namespace API.Services.Implementation;

public class CourseService(
    ITagRepository tagRepository,
    ILessonRepository lessonRepository,
    IBadgeRepository badgeRepository,
    ICourseRepository courseRepository
    ) : ICourseService
{
    public async Task<bool> CreateAsync(CourseInputModel courseInputModel)
    {
        Badge? badge = await badgeRepository.GetByNameAsync(courseInputModel.BadgeName);
        if (badge == null)
        {
            return false;
        }

        List<Tag> tags = [];
        foreach (string tagName in courseInputModel.TagNames)
        {
            Tag? tag = await tagRepository.GetByNameAsync(tagName);
            tags.Add(tag ?? new Tag { Name = tagName });
        }

        List<Lesson> lessons = [];
        lessons.AddRange(courseInputModel.LessonTitles.Select(lessonTitle => new Lesson { Title = lessonTitle }));

        Course course = new Course
        {
            Title = courseInputModel.Title,
            Description = courseInputModel.Description,
            Duration = courseInputModel.Duration,
            Badge = badge,
            Tags = tags,
            Lessons = lessons
        };

        Course? createdCourse = await courseRepository.CreateAsync(course);

        return createdCourse != null;
    }
}