using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class QuizForm
{
    public Guid Id { get; set; }

    [StringLength(128)] public string Title { get; set; } = string.Empty;
}