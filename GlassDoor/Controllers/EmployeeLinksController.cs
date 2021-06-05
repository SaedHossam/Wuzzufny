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
    public class EmployeeLinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeLinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeLinks>>> GetEmployeeLinks()
        {
            return await _context.EmployeeLinks.ToListAsync();
        }

        // GET: api/EmployeeLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeLinks>> GetEmployeeLinks(int id)
        {
            var employeeLinks = await _context.EmployeeLinks.FindAsync(id);

            if (employeeLinks == null)
            {
                return NotFound();
            }

            return employeeLinks;
        }

        // PUT: api/EmployeeLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeLinks(int id, EmployeeLinks employeeLinks)
        {
            if (id != employeeLinks.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeLinks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeLinksExists(id))
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

        // POST: api/EmployeeLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeLinks>> PostEmployeeLinks(EmployeeLinks employeeLinks)
        {
            _context.EmployeeLinks.Add(employeeLinks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeLinks", new { id = employeeLinks.Id }, employeeLinks);
        }

        // DELETE: api/EmployeeLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeLinks(int id)
        {
            var employeeLinks = await _context.EmployeeLinks.FindAsync(id);
            if (employeeLinks == null)
            {
                return NotFound();
            }

            _context.EmployeeLinks.Remove(employeeLinks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeLinksExists(int id)
        {
            return _context.EmployeeLinks.Any(e => e.Id == id);
        }
    }
}
