using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArticleService.Infrastructure.Models;

[Table("Articles")]
public class ArticleDbModel
{
    [StringLength(1000)]
    public string? Author { get; set; }

    [StringLength(1000)]
    public string? Content { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    public DateTime? PublishedOn { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
