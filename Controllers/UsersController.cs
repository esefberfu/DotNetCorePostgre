using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DotNetCorePostgre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context.ApplicationContext _context;

        public UsersController(Context.ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _context.Find<Models.User>(id);

            return Ok(user);
        }

        [HttpPost("{id}")]
        public IActionResult Post(int id, [FromBody] Models.User user)
        {
            _context.Add(user);

            _context.SaveChanges();

            return CreatedAtRoute(nameof(id), new { id = user.id }, user);
        }
    }
}
