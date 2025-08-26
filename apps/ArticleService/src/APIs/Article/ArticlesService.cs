using ArticleService.Infrastructure;

namespace ArticleService.APIs;

public class ArticlesService : ArticlesServiceBase
{
    public ArticlesService(ArticleServiceDbContext context)
        : base(context) { }
}
