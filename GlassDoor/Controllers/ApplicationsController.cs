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
using Microsoft.AspNetCore.Identity;
using GlassDoor.ViewModels;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
     
        public ApplicationsController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }


        // GET: api/Applications/5
        [HttpGet("jobId/{jobId}")]
        public async Task<ActionResult<List<CompanyApplicationDto>>> GetApplications(int jobId)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            Job companyJob = new Job();
            try
            {
               companyJob = _unitOfWork.Jobs.GetAllJobData().Where(c => c.CompanyId == companyId & c.Id == jobId).FirstOrDefault();

            }
            catch (Exception)
            {

                return BadRequest();
            }

            var application = _context.Applications.Where(c => c.JobId == companyJob.Id)
                .Include(a => a.Employee)
                .Include(a => a.Employee.Skills)
                .Include(a => a.Employee.UserLanguages)
                .Include(a => a.Employee.EmployeeLinks)
                .Include(a => a.Employee.CareerLevel)
                .Include(a => a.Employee.EducationLevel);


            if (application == null)
            {
                return NotFound();
            }

            var applicationDto = _mapper.Map<IEnumerable<CompanyApplicationDto>>(application);

            return applicationDto.ToList();
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyApplicationDto>> GetApplication(int id)
        {
            var application = _context.Applications
                .Include(a => a.Employee)
                .Include(a => a.Employee.Skills)
                .Include(a => a.Employee.UserLanguages)
                .Include(a => a.Employee.EmployeeLinks)
                .Include(a => a.Employee.CareerLevel)
                .Include(a => a.Employee.EducationLevel)
                .Include(a => a.Employee.City)
                .Include(a => a.Employee.Country)
                .FirstOrDefault(a => a.Id == id);
            //Application application = _context.Applications.Where(a => a.Id == id)
            //    .Include(a => a.Employee)
            //    .Include(a => a.Employee.Skills)
            //    .Include(a => a.Employee.UserLanguages)
            //    .Include(a => a.Employee.EmployeeLinks)
            //    .Include(a => a.Employee.CareerLevel); 

            if (application == null)
            {
                return BadRequest();
            }

            return _mapper.Map<CompanyApplicationDto>(application);
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication(int id, Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            _context.Entry(application).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(id))
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

        //change Application status

        [HttpPut("status")]
        public async Task<IActionResult> changeApplicationStatus(ApplicationStatusDto applicationDto)
        {

            var application = _context.Applications.FirstOrDefault(a => a.Id == applicationDto.Id);
            
            if (application == null)
            {
                return BadRequest();
            }

            application.Status = applicationDto.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(applicationDto.Id))
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

        // POST: api/Applications
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Application>> PostApplication(Application application)
        {
            _context.Applications.Add(application);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        }

        // DELETE: api/Applications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            var application = await _context.Applications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            _context.Applications.Remove(application);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
