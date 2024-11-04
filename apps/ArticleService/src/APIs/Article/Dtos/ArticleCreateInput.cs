namespace ArticleService.APIs.Dtos;

public class ArticleCreateInput
{
    public string? Author { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Id { get; set; }

    public DateTime? PublishedOn { get; set; }

    public string? Title { get; set; }

    public DateTime UpdatedAt { get; set; }
}
