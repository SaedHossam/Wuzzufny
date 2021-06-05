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
    public class EducationLevelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EducationLevelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EducationLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EducationLevel>>> GetEducationLevels()
        {
            return await _context.EducationLevels.ToListAsync();
        }

        // GET: api/EducationLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EducationLevel>> GetEducationLevel(int id)
        {
            var educationLevel = await _context.EducationLevels.FindAsync(id);

            if (educationLevel == null)
            {
                return NotFound();
            }

            return educationLevel;
        }

        // PUT: api/EducationLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEducationLevel(int id, EducationLevel educationLevel)
        {
            if (id != educationLevel.Id)
            {
                return BadRequest();
            }

            _context.Entry(educationLevel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationLevelExists(id))
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

        // POST: api/EducationLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EducationLevel>> PostEducationLevel(EducationLevel educationLevel)
        {
            _context.EducationLevels.Add(educationLevel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEducationLevel", new { id = educationLevel.Id }, educationLevel);
        }

        // DELETE: api/EducationLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducationLevel(int id)
        {
            var educationLevel = await _context.EducationLevels.FindAsync(id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            _context.EducationLevels.Remove(educationLevel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EducationLevelExists(int id)
        {
            return _context.EducationLevels.Any(e => e.Id == id);
        }
    }
}
