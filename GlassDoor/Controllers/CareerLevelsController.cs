using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerLevelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CareerLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CareerLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareerLevel>>> GetCareerLevels()
        {
            return await _context.CareerLevels.ToListAsync();
        }

        // GET: api/CareerLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareerLevel>> GetCareerLevel(int id)
        {
            var careerLevel = await _context.CareerLevels.FindAsync(id);

            if (careerLevel == null)
            {
                return NotFound();
            }

            return careerLevel;
        }

        // PUT: api/CareerLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerLevel(int id, CareerLevel careerLevel)
        {
            if (id != careerLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(careerLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerLevelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CareerLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CareerLevel>> PostCareerLevel(CareerLevel careerLevel)
        {
            _context.CareerLevels.Add(careerLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCareerLevel", new { id = careerLevel.Id }, careerLevel);
        }

        // DELETE: api/CareerLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareerLevel(int id)
        {
            var careerLevel = await _context.CareerLevels.FindAsync(id);
            if (careerLevel == null)
            {
                return NotFound();
            }

            _context.CareerLevels.Remove(careerLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CareerLevelExists(int id)
        {
            return _context.CareerLevels.Any(e => e.Id == id);
        }
    }
}
