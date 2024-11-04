using Microsoft.AspNetCore.Mvc;

namespace ArticleService.APIs;

[ApiController()]
public class ArticlesController : ArticlesControllerBase
{
    public ArticlesController(IArticlesService service)
        : base(service) { }
}
