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
    public class SalaryRatesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalaryRatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalaryRates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalaryRate>>> GetSalaryRates()
        {
            return await _context.SalaryRates.ToListAsync();
        }

        // GET: api/SalaryRates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryRate>> GetSalaryRate(int id)
        {
            var salaryRate = await _context.SalaryRates.FindAsync(id);

            if (salaryRate == null)
            {
                return NotFound();
            }

            return salaryRate;
        }

        // PUT: api/SalaryRates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalaryRate(int id, SalaryRate salaryRate)
        {
            if (id != salaryRate.Id)
            {
                return BadRequest();
            }

            _context.Entry(salaryRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryRateExists(id))
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

        // POST: api/SalaryRates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalaryRate>> PostSalaryRate(SalaryRate salaryRate)
        {
            _context.SalaryRates.Add(salaryRate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalaryRate", new { id = salaryRate.Id }, salaryRate);
        }

        // DELETE: api/SalaryRates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalaryRate(int id)
        {
            var salaryRate = await _context.SalaryRates.FindAsync(id);
            if (salaryRate == null)
            {
                return NotFound();
            }

            _context.SalaryRates.Remove(salaryRate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryRateExists(int id)
        {
            return _context.SalaryRates.Any(e => e.Id == id);
        }
    }
}
