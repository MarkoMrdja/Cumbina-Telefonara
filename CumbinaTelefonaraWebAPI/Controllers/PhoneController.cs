using CumbinaTelefonaraWebAPI.Data;
using CumbinaTelefonaraWebAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CumbinaTelefonaraWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private static AppDbContext _context;

        public PhoneController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var phones = await _context.Phones.ToListAsync();
            return Ok(phones);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var phone = await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);
            if(phone == null)
                return BadRequest("Invalid ID");

            return Ok(phone);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Phone phone)
        {

            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", phone.Id, phone);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int id, int batteryLife)
        {
            var phone = await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);
            if (phone == null)
                return BadRequest("Invalid ID");

            phone.BatteryLife = batteryLife;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var phone = await _context.Phones.FirstOrDefaultAsync(x => x.Id == id);

            if (phone == null)
                return BadRequest("Invalid ID");

            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
