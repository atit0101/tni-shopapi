using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
	{
        private readonly PapayaDbContext _context;

        public ImageController(PapayaDbContext context)
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetCatagorys()
        {
            try
            {
                var imagesdata = await _context.images.ToListAsync();

                Console.WriteLine(JsonSerializer.Serialize(imagesdata));

                var res = new ResponseModel
                {
                    Status = "Success",
                    Data = imagesdata
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

