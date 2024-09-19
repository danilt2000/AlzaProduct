using System.Runtime.InteropServices;
using AlzaProduct.Core.Interfaces.Persistent;
using Microsoft.AspNetCore.Mvc;

namespace AlzaProduct.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IRepository _repository;

        public TestController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet(Name = "Ping")]
        public IActionResult Get()
        {
            var dotNetVersion = RuntimeInformation.FrameworkDescription;

            return Ok(new { message = "Ping", dotNetVersion });
        }
    }
}
