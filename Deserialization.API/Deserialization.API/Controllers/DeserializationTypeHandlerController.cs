using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Deserialization.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Deserialization.API.Controllers
{
    public class DeserializationTypeHandlerController : Controller
    {

        private readonly UserContext _context;

        public DeserializationTypeHandlerController(UserContext context)
        {
            _context = context;
        }

        // POST api/values
        [Route("api/deserialize")]
        [HttpPost]
        public IActionResult Post([FromBody]Object value)
        {
            try
            {
                _context.Add(value);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
