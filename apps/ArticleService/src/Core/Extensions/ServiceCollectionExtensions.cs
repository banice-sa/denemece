using ArticleService.APIs;

namespace ArticleService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IArticlesService, ArticlesService>();
    }
}
