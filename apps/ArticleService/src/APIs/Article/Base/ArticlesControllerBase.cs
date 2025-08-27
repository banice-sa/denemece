using ArticleService.APIs;
using ArticleService.APIs.Common;
using ArticleService.APIs.Dtos;
using ArticleService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ArticlesControllerBase : ControllerBase
{
    protected readonly IArticlesService _service;

    public ArticlesControllerBase(IArticlesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Article
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Article>> CreateArticle(ArticleCreateInput input)
    {
        var article = await _service.CreateArticle(input);

        return CreatedAtAction(nameof(Article), new { id = article.Id }, article);
    }

    /// <summary>
    /// Find many Articles
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Article>>> Articles(
        [FromQuery()] ArticleFindManyArgs filter
    )
    {
        return Ok(await _service.Articles(filter));
    }

    /// <summary>
    /// Meta data about Article records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ArticlesMeta(
        [FromQuery()] ArticleFindManyArgs filter
    )
    {
        return Ok(await _service.ArticlesMeta(filter));
    }

    /// <summary>
    /// Update one Article
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateArticle(
        [FromRoute()] ArticleWhereUniqueInput uniqueId,
        [FromQuery()] ArticleUpdateInput articleUpdateDto
    )
    {
        try
        {
            await _service.UpdateArticle(uniqueId, articleUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
