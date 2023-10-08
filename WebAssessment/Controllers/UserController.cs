using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAssessment.Data;

namespace WebAssessment.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDetails>), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // POST: api/users
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<UserDetails>), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult Post([FromBody] UserDetails user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UserDetails>), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult Put(int id, [FromBody] UserDetails user)
        {
            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = user.Username;
            existingUser.Mail = user.Mail;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Skillsets = user.Skillsets;
            existingUser.Hobby = user.Hobby;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UserDetails>), 200)] // 200 OK
        [ProducesResponseType(404)] // Not Found
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }


}
