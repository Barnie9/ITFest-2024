namespace API.Entities;

public class UserCourse
{
    public Guid UserId { get; init; }
    public User? User { get; init; }

    public Guid CourseId { get; init; }
    public Course? Course { get; init; }

    public int CurrentLevel { get; set; }
    public bool Completed { get; set; }
}