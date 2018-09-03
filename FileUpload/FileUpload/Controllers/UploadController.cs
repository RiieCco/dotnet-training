using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {

        public readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromForm]IFormFile value, string fileName)
        {
            try
            {
                var uploads = Path.Combine(_environment.WebRootPath, "images");
                if (value.FileName != null)
                {
                    if (value.ContentType != "image/jpeg")
                    {
                        return BadRequest("Content type not permitted!");
                    }
                    if (value.Length > 0)
                    {
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            value.CopyToAsync(fileStream);
                        }
                    }
                }
               return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
