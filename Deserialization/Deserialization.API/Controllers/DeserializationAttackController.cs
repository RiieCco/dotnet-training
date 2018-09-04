using Deserialization.Classes;
using Deserialization.Models;
using Deserialization.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Deserialization.API.Controllers
{
    public class DeserializationAttackController : Controller
    {

        private readonly UserContext _context;

        public DeserializationAttackController(UserContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a serialized XML file that can be found in the source-code
        /// </summary>
        // POST api/values
        [Route("api/deserialize")]
        [HttpGet]
        public IActionResult Get()
        {
            //This function creates the template to get the serialized object from to form the attack
            XMLSerialization serilization = new XMLSerialization();
            serilization.SerializeToXml("test.xml");
            return Ok();
        }

        /// <summary>
        /// Gets the serialized XML object to the deserialization function (from test.xml)
        /// </summary>
        // POST api/values
        [Route("api/deserialize")]
        [HttpPost]
        public IActionResult Post()
        {
            XMLSerialization serilization = new XMLSerialization();
            serilization.DeSerializeFromXml("test.xml");
            return Ok();
        }
    }
}
