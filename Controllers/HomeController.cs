using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{

    [ApiController]
    [Route("v1")]
    public class HomeController : ControllerBase
    {
        [HttpGet("health-check")]
        public ActionResult Get() {

            return Ok(new
            {
               obj = "Api is Avaible"
            });
               
        }
    }
}
