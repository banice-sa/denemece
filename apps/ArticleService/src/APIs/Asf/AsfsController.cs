using ArticleService.APIs;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.APIs;

[ApiController()]
public class AsfsController : AsfsControllerBase
{
    public AsfsController(IAsfsService service)
        : base(service) { }
}
