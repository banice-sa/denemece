using ArticleService.APIs;
using Microsoft.AspNetCore.Mvc;

namespace ArticleService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AsfsControllerBase : ControllerBase
{
    protected readonly IAsfsService _service;

    public AsfsControllerBase(IAsfsService service)
    {
        _service = service;
    }
}
