namespace API.Entities;

public class UserChapter
{
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid ChapterId { get; set; }
    public Chapter? Chapter { get; set; }

    public bool Completed { get; set; }
}