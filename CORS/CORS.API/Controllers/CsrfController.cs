using System;
using System.Linq;
using Authorization.API.ViewModels;
using CORS.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Authorization.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Csrf")]
    public class CsrfController : Controller
    {

        private readonly IdentityContext _myContext;
        public CsrfController(IdentityContext myContext) { _myContext = myContext; }

        // GET: api/Csrf
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var list = _myContext.Csrf.ToList();
            var listJson = JsonConvert.SerializeObject(list);
            return Ok(listJson);
        }
        
        // POST: api/Csrf
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]CsrfViewModel value)
        {
            if (ModelState.IsValid)
            {
                CsrfModel csrf = new CsrfModel { PrivateData = value.PrivateData, PrivateDateTime = DateTime.Now };
                _myContext.Csrf.Add(csrf);
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
        public IActionResult Put(int id, [FromBody]CsrfViewModel value)
        {
            if (ModelState.IsValid)
            {
                var result = _myContext.Csrf.SingleOrDefault(x => x.PrivateDataId == id);
                if (result != null)
                {
                    result.PrivateData = value.PrivateData;
                    result.PrivateDateTime = DateTime.Now;
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
            CsrfModel csrf = new CsrfModel { PrivateDataId = id };
            _myContext.Csrf.Attach(csrf);
            _myContext.Csrf.Remove(csrf);
            _myContext.SaveChanges();
        }
    }
}
