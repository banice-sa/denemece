using ArticleService.APIs;
using ArticleService.APIs.Common;
using ArticleService.APIs.Dtos;
using ArticleService.APIs.Errors;
using ArticleService.APIs.Extensions;
using ArticleService.Infrastructure;
using ArticleService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleService.APIs;

public abstract class ArticlesServiceBase : IArticlesService
{
    protected readonly ArticleServiceDbContext _context;

    public ArticlesServiceBase(ArticleServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Article
    /// </summary>
    public async Task<Article> CreateArticle(ArticleCreateInput createDto)
    {
        var article = new ArticleDbModel
        {
            Author = createDto.Author,
            Content = createDto.Content,
            CreatedAt = createDto.CreatedAt,
            PublishedOn = createDto.PublishedOn,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            article.Id = createDto.Id;
        }

        _context.Articles.Add(article);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ArticleDbModel>(article.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Article
    /// </summary>
    public async Task DeleteArticle(ArticleWhereUniqueInput uniqueId)
    {
        var article = await _context.Articles.FindAsync(uniqueId.Id);
        if (article == null)
        {
            throw new NotFoundException();
        }

        _context.Articles.Remove(article);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Articles
    /// </summary>
    public async Task<List<Article>> Articles(ArticleFindManyArgs findManyArgs)
    {
        var articles = await _context
            .Articles.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return articles.ConvertAll(article => article.ToDto());
    }

    /// <summary>
    /// Meta data about Article records
    /// </summary>
    public async Task<MetadataDto> ArticlesMeta(ArticleFindManyArgs findManyArgs)
    {
        var count = await _context.Articles.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Article
    /// </summary>
    public async Task<Article> Article(ArticleWhereUniqueInput uniqueId)
    {
        var articles = await this.Articles(
            new ArticleFindManyArgs { Where = new ArticleWhereInput { Id = uniqueId.Id } }
        );
        var article = articles.FirstOrDefault();
        if (article == null)
        {
            throw new NotFoundException();
        }

        return article;
    }

    /// <summary>
    /// Update one Article
    /// </summary>
    public async Task UpdateArticle(ArticleWhereUniqueInput uniqueId, ArticleUpdateInput updateDto)
    {
        var article = updateDto.ToModel(uniqueId);

        _context.Entry(article).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Articles.Any(e => e.Id == article.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
