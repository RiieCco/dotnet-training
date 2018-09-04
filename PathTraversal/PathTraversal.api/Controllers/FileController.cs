using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PathTraversal.api.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        public readonly IHostingEnvironment _environment;

        public FileController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        /// <summary>
        /// Is used to get content.txt (Payload =  "content.txt" )
        /// </summary>
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string filename)
        {
            try
            {
                var basePath = Path.Combine(_environment.WebRootPath, "content");
                FileStream fileStream = new FileStream(Path.Combine(basePath, filename), FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string line = reader.ReadToEnd();
                    return Ok(line);
                }
            }
            catch (Exception e)
            {
                return NotFound(e);
            }
        }
    }
}
