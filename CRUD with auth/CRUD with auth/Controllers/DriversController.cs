using CRUD_with_auth.Data;
using CRUD_with_auth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_with_auth.Controllers
{
    /*
     * In postman, 
     * in header section
     * Add authorization and token as value to get access to the controller
     */
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("/api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DriversController(AppDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var drivers = await _context.Drivers.ToListAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(!ModelState.IsValid) { 
            return BadRequest(ModelState);
            }
            return Ok(_context.Drivers.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        [Route(template: "Add Driver")]
        public IActionResult AddDriver(CreateDriver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Drivers.Add(new Driver
            {
                DriverNumber = driver.DriverNumber,
                Name = driver.Name,
                Team = driver.Team,
            });
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [Route(template: "Delete Driver")]
        public IActionResult DeleteDriver(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var driver = _context.Drivers.FirstOrDefault(x => x.Id == id);

            if (driver == null)
            {
                return NotFound();

            }
            _context.Drivers.Remove(driver);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch]
        [Route(template: "Update Driver")]
        public IActionResult UpdateDriver(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existDriver = _context.Drivers.FirstOrDefault(x => x.Id == driver.Id);

            if (existDriver == null)
            {
                return NotFound();
            }
            existDriver.Name = driver.Name;
            existDriver.DriverNumber = driver.DriverNumber;
            existDriver.Team = driver.Team;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
