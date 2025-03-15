namespace API.Entities;

public class UserLearningCourse
{
    public Guid UserId { get; init; }
    public User? User { get; init; }

    public Guid CourseId { get; init; }
    public LearningCourse? LearningCourse { get; init; }

    public bool Completed { get; set; }
}