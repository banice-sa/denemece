using ArticleService.APIs.Dtos;
using ArticleService.Infrastructure.Models;

namespace ArticleService.APIs.Extensions;

public static class ArticlesExtensions
{
    public static Article ToDto(this ArticleDbModel model)
    {
        return new Article
        {
            Author = model.Author,
            Content = model.Content,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            PublishedOn = model.PublishedOn,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static ArticleDbModel ToModel(
        this ArticleUpdateInput updateDto,
        ArticleWhereUniqueInput uniqueId
    )
    {
        var article = new ArticleDbModel
        {
            Id = uniqueId.Id,
            Author = updateDto.Author,
            Content = updateDto.Content,
            PublishedOn = updateDto.PublishedOn,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            article.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            article.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return article;
    }
}
