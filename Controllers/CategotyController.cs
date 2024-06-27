using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategotyController : ControllerBase
	{
        private readonly PapayaDbContext _context;

        public CategotyController(PapayaDbContext context)
        {
            _context = context;
        }

        [HttpGet("testconnectdb")]
        public void TestConnecttion()
        {
            if (_context.Database.CanConnect())
            {
                Response.WriteAsync("Connected");
            }
            else
            {
                Response.WriteAsync("Not Connected");
            }
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetCatagorys()
        {
            try
            {
                var categorydata = await _context.categories.ToListAsync();

                Console.WriteLine(JsonSerializer.Serialize(categorydata));

                var res = new ResponseModel
                {
                    Status = "Success",
                    Data = categorydata
                };
                return Ok(res);
            }
            catch(Exception error)
            {
                return StatusCode(500, error.Message);
            }
            
        }
    }

}

