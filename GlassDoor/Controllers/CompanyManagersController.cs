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
    public class CompanyManagersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyManager>>> GetCompanyManagers()
        {
            return await _context.CompanyManagers.ToListAsync();
        }

        // GET: api/CompanyManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyManager>> GetCompanyManager(int id)
        {
            var companyManager = await _context.CompanyManagers.FindAsync(id);

            if (companyManager == null)
            {
                return NotFound();
            }

            return companyManager;
        }

        // PUT: api/CompanyManagers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyManager(int id, CompanyManager companyManager)
        {
            if (id != companyManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyManagerExists(id))
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

        // POST: api/CompanyManagers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyManager>> PostCompanyManager(CompanyManager companyManager)
        {
            _context.CompanyManagers.Add(companyManager);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyManager", new { id = companyManager.Id }, companyManager);
        }

        // DELETE: api/CompanyManagers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyManager(int id)
        {
            var companyManager = await _context.CompanyManagers.FindAsync(id);
            if (companyManager == null)
            {
                return NotFound();
            }

            _context.CompanyManagers.Remove(companyManager);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyManagerExists(int id)
        {
            return _context.CompanyManagers.Any(e => e.Id == id);
        }
    }
}
