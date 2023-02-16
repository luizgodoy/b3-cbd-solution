using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B3.CDB.Main.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Serviços em execução!");
        }
    }
}
