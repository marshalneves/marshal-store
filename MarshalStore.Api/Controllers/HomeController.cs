using Microsoft.AspNetCore.Mvc;

namespace MarshalStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public string Get()
        {
            return "Version 0.0.1";
        }
    }
}