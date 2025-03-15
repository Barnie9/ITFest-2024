using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class ChapterElement
{
    public Guid Id { get; set; }

    public int Index { get; set; }
    [StringLength(128)] public string Title { get; set; } = string.Empty;
    [StringLength(64)] public string Type { get; set; } = string.Empty;
    public string? Content { get; set; }
    public byte[]? Image { get; set; }
    public Guid? FormId { get; set; }
    public QuizForm? Form { get; set; }
}