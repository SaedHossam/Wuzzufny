using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using GlassDoor.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GlassDoor.Constants;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public CompaniesController(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, Company company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[Authorize]
        // Get Requests for Creating Companies
        [Authorize(Roles = "Administrator")]
        [HttpGet("companiesRequests")]
        public ActionResult<IEnumerable<CompanyRequestsDto>> GetCompaniesRequests()
        {
            try
            {
                var statusId = _context.CompanyRequestStatus.FirstOrDefault(s => s.Name == Enums.CompanyRequestStatus.UnderReview.ToString()).Id;
                var companies =
                    _mapper.Map<IEnumerable<CompanyRequestsDto>>(
                        _context.Companies
                        .Include(s => s.CompanySize)
                        .Include(i => i.CompanyIndustry)
                        .Where(a => a.RequestStatusId == statusId));

                return Ok(companies);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        // Get Company Request by Id
        [Authorize(Roles = "Administrator")]
        [HttpGet("companiesRequests/{id}")]
        public ActionResult<CompanyRequestDto> GetCompanyRequest(int id)
        {
            Company company =
                _context.Companies
                .Include(s => s.CompanySize)
                .Include(i => i.CompanyIndustry)
                .Include(m => m.CompanyManagers)
                .ThenInclude(u => u.User)
                .Where(c => c.Id == id)
                .FirstOrDefault();

            var user = company.CompanyManagers.FirstOrDefault().User;
            CompanyRequestDto companyRequest = new CompanyRequestDto()
            {
                Id = company.Id,
                Name = company.Name,
                Industry = company.CompanyIndustry.Name,
                Size = company.CompanySize.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Title = company.CompanyManagers.FirstOrDefault().Title,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            if (companyRequest == null)
            {
                return NotFound();
            }

            return Ok(companyRequest);
        }

        // post method that takes bool value that indicate weather request is confiremed or not
        [Authorize(Roles = "Administrator")]
        [HttpPost("requestStatus")]
        public ActionResult PostRequestStatus(int id, bool res)
        {
            Company company =
                _context.Companies
                .Where(c => c.Id == id)
                .Include(a => a.RequestStatus)
                .FirstOrDefault();
            int statusId;
            if(company.RequestStatus.Name == Enums.CompanyRequestStatus.UnderReview.ToString())
            {
                if (res)
                {
                    statusId = _context.CompanyRequestStatus.FirstOrDefault(a => a.Name == Enums.CompanyRequestStatus.Accepted.ToString()).Id;
                }
                else
                {
                    statusId = _context.CompanyRequestStatus.FirstOrDefault(a => a.Name == Enums.CompanyRequestStatus.Rejected.ToString()).Id;
                }
                company.RequestStatusId = statusId;
                _context.SaveChanges();
                return Ok("Request Updated");
            }
            else
            {
                return StatusCode(500, "Can't change Company Status");
            }
        }
        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
