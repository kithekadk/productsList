using Microsoft.AspNetCore.Mvc;

namespace product_Crud_Dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("")]
        public IActionResult HandleError() => Problem();
    }
}
