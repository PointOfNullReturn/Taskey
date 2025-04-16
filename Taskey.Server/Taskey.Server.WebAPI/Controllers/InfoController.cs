using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taskey.Server.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInfo()
        {
            var info = new
            {
                Version = "1.0.0",
                Description = "Taskey API is a simple task tracker API."
            };
            return Ok(info);
        }
    }
}
