using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HoopRunAPI.Controllers
{
    [Route("api/[controller]")]
    [Route("api/")]
    [Route("/")]
    [ApiController]

    public class WelcomeController : Controller
    {
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Welcome to the API"};
        }
    }
}