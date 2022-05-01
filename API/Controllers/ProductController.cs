using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly StoreContext _context;

        public ProductController(ILogger<ProductController> logger, StoreContext context)
        {
            _context = context;
            _logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProduct()
        {

            return await _context.Products.ToListAsync();

        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id)
        {


            return await _context.Products.FindAsync(id);

        }




    }
}