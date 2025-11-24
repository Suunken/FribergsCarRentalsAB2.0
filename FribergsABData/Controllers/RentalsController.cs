using FribergsABData.Dto;
using FribergsABData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FribergsABData.Controllers
{
    [Route("api/Rentals")]
    [ApiController]

    public class RentalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var rentals = await _context.Rentals.ToListAsync();
            return Ok(rentals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetId(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound($"Hittar inget med id:{id}");
            }
            return rental;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RentalDto rentalDto)
        {
            if (rentalDto == null)
            {
                return BadRequest("Nej");
            }
            var rental = new Rental
            {
                UserId = rentalDto.UserId,
                CarId = rentalDto.CarId,
                Start = rentalDto.Start,
                End = rentalDto.End
            };
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { id = rental.Id }, rentalDto);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Rental rentals)
        {
            if (id != rentals.Id)
            {
                return BadRequest($"Hittade ingen uthyrning med ID:{id}");
            }

            var changeRental = await _context.Rentals.FindAsync(id);

            if (changeRental == null)
            {
                return BadRequest($"Hittade ingen uthyrning med ID:{id} försök igen.");
            }
          
            {
                changeRental.UserId = rentals.UserId;
                changeRental.CarId = rentals.CarId;
                changeRental.Start = rentals.Start;
                changeRental.End = rentals.End;

            };
            _context.Rentals.Add(rentals);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetId), new { id = rentals.Id }, rentals);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var deleteRental = await _context.Rentals.FindAsync(id);
            if (id == null)
            {
                return BadRequest($"Hittade ingen uthyrning med ID:{id}");
            }
            _context.Rentals.Remove(deleteRental);
            await _context.SaveChangesAsync();
            return Ok(deleteRental);
        }


    }
}
