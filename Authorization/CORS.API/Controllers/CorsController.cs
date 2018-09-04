using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CORS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cors")]
    public class CorsController : Controller
    {

        /// <summary>
        /// Returns one secret value to be gotten from other server! 
        /// </summary>
        // GET: api/Cors
        [HttpGet]
        [Authorize]
        public IActionResult Get() => Ok("If you can read this from another server the attack was successfull!");
    }
}
