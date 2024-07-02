using System;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly PapayaDbContext _context;

        public ProductController(PapayaDbContext context)
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetProducts()
        {
            try
            {
                var products = await _context.products.ToArrayAsync();
                var res = new ResponseModel
                {
                    Status = "success",
                    Data = products
                };

                return Ok(res);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

        [HttpGet("{category_id}")]
        public async Task<ActionResult> GetProductByCategory(int category_id)
        {
            try
            {
                var products = await _context.products
                    .Where(p => p.category_id == category_id)
                    .ToListAsync();

                var res = new ResponseModel
                {
                    Status = "success",
                    Data = products
                };

                return Ok(res);
            }
            catch (Exception error)
            {
                return StatusCode(500, error.Message);
            }
        }

    }
}

