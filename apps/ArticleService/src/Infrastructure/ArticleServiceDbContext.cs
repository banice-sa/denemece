using ArticleService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleService.Infrastructure;

public class ArticleServiceDbContext : DbContext
{
    public ArticleServiceDbContext(DbContextOptions<ArticleServiceDbContext> options)
        : base(options) { }

    public DbSet<ArticleDbModel> Articles { get; set; }
}
