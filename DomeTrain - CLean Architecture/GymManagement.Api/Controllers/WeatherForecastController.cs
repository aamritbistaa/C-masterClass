using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet("HelloWorld")]
        public async Task<string> SayHello()
        {
            
            return "Helloworld";
        }
    }
}
