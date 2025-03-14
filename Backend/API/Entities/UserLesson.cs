namespace API.Entities;

public class UserLesson
{
    public Guid UserId { get; init; }
    public User? User { get; init; }

    public Guid LessonId { get; init; }
    public Lesson? Lesson { get; init; }

    public bool Completed { get; set; }
}