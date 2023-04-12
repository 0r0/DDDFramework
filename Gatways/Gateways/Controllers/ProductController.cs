

using Microsoft.AspNetCore.Mvc;

namespace Gateways.Controllers;
[ApiController]
[Route("api")]
public class ProductController :ControllerBase
{
    [HttpGet("love")]
    public ActionResult<string> GetLove()
    {
        return "love";
    }
}