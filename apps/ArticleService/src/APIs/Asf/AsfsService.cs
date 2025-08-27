using ArticleService.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.APIs;

public class AsfsService : AsfsServiceBase
{
    public AsfsService(ArticleServiceDbContext context)
        : base(context) { }
}
