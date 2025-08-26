using ArticleService.APIs;
using ArticleService.Infrastructure;
using ArticleService.Infrastructure.Models;

namespace ArticleService.APIs;

public abstract class AsfsServiceBase : IAsfsService
{
    protected readonly ArticleServiceDbContext _context;

    public AsfsServiceBase(ArticleServiceDbContext context)
    {
        _context = context;
    }
}
