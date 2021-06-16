using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using AutoMapper;
using GlassDoor.ViewModels;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyApplicationStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CompanyApplicationStatusController(IMapper mapper, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: api/CompanyApplicationStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyApplicationStatus>>> GetCompanyApplicationStatuses()
        {
           return Ok(_mapper.Map<IEnumerable<CompanyApplicationStatusDto>>(_unitOfWork.CompanyApplicationStatus.GetAll()));
        }

        // GET: api/CompanyApplicationStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyApplicationStatus>> GetCompanyApplicationStatus(int id)
        {
            var companyApplicationStatus = await _context.CompanyApplicationStatuses.FindAsync(id);

            if (companyApplicationStatus == null)
            {
                return NotFound();
            }

            return companyApplicationStatus;
        }

        // PUT: api/CompanyApplicationStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyApplicationStatus(int id, CompanyApplicationStatus companyApplicationStatus)
        {
            if (id != companyApplicationStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(companyApplicationStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyApplicationStatusExists(id))
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

        // POST: api/CompanyApplicationStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyApplicationStatus>> PostCompanyApplicationStatus(CompanyApplicationStatus companyApplicationStatus)
        {
            _context.CompanyApplicationStatuses.Add(companyApplicationStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyApplicationStatus", new { id = companyApplicationStatus.Id }, companyApplicationStatus);
        }

        // DELETE: api/CompanyApplicationStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyApplicationStatus(int id)
        {
            var companyApplicationStatus = await _context.CompanyApplicationStatuses.FindAsync(id);
            if (companyApplicationStatus == null)
            {
                return NotFound();
            }

            _context.CompanyApplicationStatuses.Remove(companyApplicationStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyApplicationStatusExists(int id)
        {
            return _context.CompanyApplicationStatuses.Any(e => e.Id == id);
        }
    }
}
