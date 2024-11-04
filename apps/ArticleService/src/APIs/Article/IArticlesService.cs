using ArticleService.APIs.Common;
using ArticleService.APIs.Dtos;

namespace ArticleService.APIs;

public interface IArticlesService
{
    /// <summary>
    /// Create one Article
    /// </summary>
    public Task<Article> CreateArticle(ArticleCreateInput article);

    /// <summary>
    /// Delete one Article
    /// </summary>
    public Task DeleteArticle(ArticleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Articles
    /// </summary>
    public Task<List<Article>> Articles(ArticleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Article records
    /// </summary>
    public Task<MetadataDto> ArticlesMeta(ArticleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Article
    /// </summary>
    public Task<Article> Article(ArticleWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Article
    /// </summary>
    public Task UpdateArticle(ArticleWhereUniqueInput uniqueId, ArticleUpdateInput updateDto);
}
