using FribergsABData.Constants;
using FribergsABData.Dto;
using FribergsABData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FribergsABData.Controllers
{
    [Route("api/Cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cars = await _context.Cars.ToListAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetId(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound($"Hittar inget med id:{id}");
            }
            return car;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarDto carDto)
        {
            if (carDto == null) 
            {
                return BadRequest("Nej");
            }
            var car = new Car
            {
                Brand = carDto.Brand,
                Color = carDto.Color,
                Rentable = carDto.Rentable,
                CarPicUrl1 = carDto.CarPicUrl1,
                CarPicUrl2 = carDto.CarPicUrl2,
            };
            

             _context.Cars.Add(car);
            await _context.SaveChangesAsync();

            

            return CreatedAtAction(nameof(GetId), new {id = car.Id}, car);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Car car)
        {

            if (id != car.Id)
            {
                return BadRequest("NEj");
            }
            var changeCar = await _context.Cars.FindAsync(id);
            if (changeCar == null)
            {
                return NotFound("NEj ingen bil");
            }

            changeCar.Brand = car.Brand;
            changeCar.Color = car.Color;
            changeCar.Rentable = car.Rentable;
            changeCar.CarPicUrl1 = car.CarPicUrl1;
            changeCar.CarPicUrl2 = car.CarPicUrl2;


            await _context.SaveChangesAsync();
            return Ok($"Du har ändrat information på id:{id}");


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCar = await _context.Cars.FindAsync(id);
            if (deleteCar == null)
            {
                return NotFound($"Hittar inget med id:{id}");
            }
            
            _context.Cars.Remove(deleteCar);
            await _context.SaveChangesAsync();
            return Ok($"Tog bort:{deleteCar.Name} | id:{deleteCar.Id}");
        }
    }
}
