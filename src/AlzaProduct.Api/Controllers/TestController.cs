using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace AlzaProduct.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet(Name = "Ping")]
        public IActionResult Get()
        {
            var dotNetVersion = RuntimeInformation.FrameworkDescription;

            return Ok(new { message = "Ping", dotNetVersion });
        }
    }
}
