using FribergsABData.Dto;
using FribergsABData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FribergsABData.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetId(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound($"Hittar ingen användare:{id}");
            }
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("Nej");
            }
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                ConfirmPassword = userDto.ConfirmPassword,
            };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();



            return CreatedAtAction(nameof(GetId), new { id = user.Id }, userDto);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {

            if (id != user.Id)
            {
                return BadRequest("NEj");
            }
            var changeUser = await _context.Users.FindAsync(id);
            if (changeUser == null)
            {
                return NotFound("NEj ingen bil");
            }

           


            await _context.SaveChangesAsync();
            return Ok($"Du har ändrat information på id:{id}");


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteUser = await _context.Users.FindAsync(id);
            if (deleteUser == null)
            {
                return NotFound($"Hittar inget med id:{id}");
            }

            _context.Users.Remove(deleteUser);
            await _context.SaveChangesAsync();
            return Ok($"Tog bort:{deleteUser.Name} | id:{deleteUser.Id}");
        }
    }
}
