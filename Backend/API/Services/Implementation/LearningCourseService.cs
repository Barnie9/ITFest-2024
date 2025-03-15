using API.Entities;
using API.Models;
using API.Repositories;

namespace API.Services.Implementation;

public class LearningCourseService(
    ITagRepository tagRepository,
    IBadgeRepository badgeRepository,
    ILearningCourseRepository learningCourseRepository
    ) : ILearningCourseService
{
    public async Task<bool> CreateAsync(LearningCourseInputModel learningCourseInputModel)
    {
        Badge? badge = await badgeRepository.GetByNameAsync(learningCourseInputModel.BadgeName);
        if (badge == null)
        {
            return false;
        }

        List<Tag> tags = [];
        foreach (string tagName in learningCourseInputModel.TagNames)
        {
            Tag? tag = await tagRepository.GetByNameAsync(tagName);
            tags.Add(tag ?? new Tag { Name = tagName });
        }

        List<Lesson> lessons = [];
        lessons.AddRange(learningCourseInputModel.LessonTitles.Select(lessonTitle => new Lesson { Title = lessonTitle }));

        LearningCourse learningCourse = new LearningCourse
        {
            Title = learningCourseInputModel.Title,
            Description = learningCourseInputModel.Description,
            Duration = learningCourseInputModel.Duration,
            Badge = badge,
            Tags = tags,
            Lessons = lessons
        };

        LearningCourse? createdCourse = await learningCourseRepository.CreateAsync(learningCourse);

        return createdCourse != null;
    }
}