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
    public class CompanyRequestStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyRequestStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyRequestStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyRequestStatus>>> GetCompanyRequestStatus()
        {
            return await _context.CompanyRequestStatus.ToListAsync();
        }

        // GET: api/CompanyRequestStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyRequestStatus>> GetCompanyRequestStatus(int id)
        {
            var companyRequestStatus = await _context.CompanyRequestStatus.FindAsync(id);

            if (companyRequestStatus == null)
            {
                return NotFound();
            }

            return companyRequestStatus;
        }

        //// PUT: api/CompanyRequestStatus/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCompanyRequestStatus(int id, CompanyRequestStatus companyRequestStatus)
        //{
        //    if (id != companyRequestStatus.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(companyRequestStatus).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CompanyRequestStatusExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/CompanyRequestStatus
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CompanyRequestStatus>> PostCompanyRequestStatus(CompanyRequestStatus companyRequestStatus)
        //{
        //    _context.CompanyRequestStatus.Add(companyRequestStatus);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCompanyRequestStatus", new { id = companyRequestStatus.Id }, companyRequestStatus);
        //}

        //// DELETE: api/CompanyRequestStatus/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompanyRequestStatus(int id)
        //{
        //    var companyRequestStatus = await _context.CompanyRequestStatus.FindAsync(id);
        //    if (companyRequestStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.CompanyRequestStatus.Remove(companyRequestStatus);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool CompanyRequestStatusExists(int id)
        {
            return _context.CompanyRequestStatus.Any(e => e.Id == id);
        }
    }
}
