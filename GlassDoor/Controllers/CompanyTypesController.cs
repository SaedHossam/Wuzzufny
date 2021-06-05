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
    public class CompanyTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyType>>> GetCompanyTypes()
        {
            return await _context.CompanyTypes.ToListAsync();
        }

        // GET: api/CompanyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyType>> GetCompanyType(int id)
        {
            var companyType = await _context.CompanyTypes.FindAsync(id);

            if (companyType == null)
            {
                return NotFound();
            }

            return companyType;
        }

        // PUT: api/CompanyTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyType(int id, CompanyType companyType)
        {
            if (id != companyType.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(id))
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

        // POST: api/CompanyTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyType>> PostCompanyType(CompanyType companyType)
        {
            _context.CompanyTypes.Add(companyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyType", new { id = companyType.Id }, companyType);
        }

        // DELETE: api/CompanyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyType(int id)
        {
            var companyType = await _context.CompanyTypes.FindAsync(id);
            if (companyType == null)
            {
                return NotFound();
            }

            _context.CompanyTypes.Remove(companyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyTypeExists(int id)
        {
            return _context.CompanyTypes.Any(e => e.Id == id);
        }
    }
}
