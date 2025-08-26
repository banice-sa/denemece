using ArticleService.APIs.Common;
using ArticleService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ArticleFindManyArgs : FindManyInput<Article, ArticleWhereInput> { }
