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
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ApplicationDto>>> GetApplication(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            Job companyJob = new Job();
            try
            {
               companyJob = _unitOfWork.Jobs.GetAllJobData().Where(c => c.CompanyId == companyId & c.Id == id).FirstOrDefault();

            }
            catch (Exception)
            {

                return BadRequest();
            }
            var application = _context.Applications.Where(c => c.jobId == companyJob.Id)
                .Include(a => a.Employee)
                .Include(a => a.Employee.Skills)
                .Include(a => a.Employee.UserLanguages)
                .Include(a => a.Employee.EmployeeLinks);

            var applicationDto = _mapper.Map<IEnumerable< ApplicationDto>>(application);


            if (application == null)
            {
                return NotFound();
            }

            return applicationDto.ToList();
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

        [HttpPut("status/{jobId}")]
        public async Task<IActionResult> changeApplicationStatus(int jobId, ApplicationStatusDto applicationDto)
        {
        

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            Job companyJob = new Job();
            try
            {
                companyJob = _context.Jobs.Where(c => c.CompanyId == companyId & c.Id == jobId).Include(a => a.Applications).FirstOrDefault();
                var application = companyJob.Applications.Where(a => a.Id == applicationDto.Id).First();
                application.Status = applicationDto.Status;
            }
            catch (Exception)
            {

                return BadRequest();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(jobId))
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
