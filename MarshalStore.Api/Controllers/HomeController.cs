using Microsoft.AspNetCore.Mvc;

namespace MarshalStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public string Get()
        {
            return "Version 0.0.1";
        }

        [HttpPost]
        [Route("")]
        public string Post()
        {
            return "Version 0.0.1";
        }

        [HttpPut]
        [Route("")]
        public string Put()
        {
            return "Version 0.0.1";
        }

        [HttpDelete]
        [Route("")]
        public string Delete()
        {
            return "Version 0.0.1";
        }

    }
}