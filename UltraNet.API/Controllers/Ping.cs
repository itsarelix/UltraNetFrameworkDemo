using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace UltraNet.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {


        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("API is alive!");
        }



    }

}


