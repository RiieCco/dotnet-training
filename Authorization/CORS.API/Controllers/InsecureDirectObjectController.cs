using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authorization.API.Models;
using Authorization.API.ViewModels;
using CORS.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Authorization.API.Controllers
{
    [Produces("application/json")]
    [Route("api/InsecureDirectObect")]
    public class InsecureDirectObjectController : Controller
    {
        private readonly IdentityContext _myContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public InsecureDirectObjectController(IdentityContext myContext, IHttpContextAccessor httpContextAccessor)
        {
            _myContext = myContext;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: api/Csrf
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            string username = _httpContextAccessor.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == "User").Value.ToString();
            var list = _myContext.Idor.Where(x => x.Owner == username);
            var listJson = JsonConvert.SerializeObject(list);

            return Ok(listJson);
        }

        // POST: api/Csrf
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]IdorViewModel idor)
        {
            if (ModelState.IsValid)
            {
                string username = _httpContextAccessor.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == "User").Value.ToString();
                IdorModel value = new IdorModel { IdorValue = idor.IdorValue, Owner = username};
                _myContext.Idor.Add(value);
                _myContext.SaveChanges();
                return Ok("New value was stored succesfull!");
            }
            else
            {
                return BadRequest("Storing the item has failed!");
            }
        }

        // PUT: api/Csrf/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody]IdorViewModel value)
        {
            if (ModelState.IsValid)
            {
                var result = _myContext.Idor.SingleOrDefault(x => x.IdorId == id);
                if (result != null)
                {
                    result.IdorValue = value.IdorValue;
                    _myContext.Update(result);
                    _myContext.SaveChanges();
                }
                return Ok("New value was updated succesfull!");
            }
            else
            {
                return BadRequest("Update of the item has failed!");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            IdorModel idor = new IdorModel { IdorId = id };
            _myContext.Idor.Attach(idor);
            _myContext.Idor.Remove(idor);
            _myContext.SaveChanges();
        }
    }
}
