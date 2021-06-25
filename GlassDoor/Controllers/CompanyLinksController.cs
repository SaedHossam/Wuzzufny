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
    public class CompanyLinksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyLinksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyLinks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyLinks>>> GetCompanyLinks()
        {
            return await _context.CompanyLinks.ToListAsync();
        }

        // GET: api/CompanyLinks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyLinks>> GetCompanyLinks(int id)
        {
            var companyLinks = await _context.CompanyLinks.FindAsync(id);

            if (companyLinks == null)
            {
                return NotFound();
            }

            return companyLinks;
        }

        // PUT: api/CompanyLinks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyLinks(int id, CompanyLinks companyLinks)
        {
            if (id != companyLinks.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyLinks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyLinksExists(id))
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

        // POST: api/CompanyLinks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyLinks>> PostCompanyLinks(CompanyLinks companyLinks)
        {
            _context.CompanyLinks.Add(companyLinks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyLinks", new { id = companyLinks.Id }, companyLinks);
        }

        // DELETE: api/CompanyLinks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyLinks(int id)
        {
            var companyLinks = await _context.CompanyLinks.FindAsync(id);
            if (companyLinks == null)
            {
                return NotFound();
            }

            _context.CompanyLinks.Remove(companyLinks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyLinksExists(int id)
        {
            return _context.CompanyLinks.Any(e => e.Id == id);
        }
    }
}
