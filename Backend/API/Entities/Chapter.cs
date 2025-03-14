namespace API.Entities;

public class Chapter
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public List<ChapterElement> Elements { get; set; } = [];
}