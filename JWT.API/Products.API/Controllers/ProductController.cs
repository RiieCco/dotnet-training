using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.Models;

namespace Products.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductContext _productContext;

        public ProductController(ProductContext context)
        {
            _productContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: retrieve al the products 
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            return StatusCode(200, "You solved the challenge!");
        }
    }
}