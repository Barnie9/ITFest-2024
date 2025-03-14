namespace API.Entities;

public class UserBadge
{
    public Guid UserId { get; init; }
    public User? User { get; init; }

    public Guid BadgeId { get; init; }
    public Badge? Badge { get; init; }

    public int Level { get; set; }
}