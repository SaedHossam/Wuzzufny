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
using Microsoft.AspNetCore.Authorization;
using GlassDoor.Constants;

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

        public ApplicationsController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _context = context;
        }

        // GET: api/Applications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            return await _context.Applications.ToListAsync();
        }


        // GET: api/Applications/5
        [HttpGet("jobId/{jobId}/{status?}")]
        [Authorize(Roles = Authorization.Company)]
        public async Task<ActionResult<List<CompanyApplicationDto>>> GetApplications(int jobId, string status = null)
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

            var applications = _context.Applications.Where(a => a.JobId == companyJob.Id)
                .Include(a => a.Employee)
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Employee.User)
                .Include(a => a.Employee.Country)
                .Include(a => a.Employee.City)
                .Include(a => a.Employee.Skills)
                .Include(a => a.Employee.UserLanguages)
                .Include(a => a.Employee.EmployeeLinks)
                .Include(a => a.Employee.CareerLevel)
                .Include(a => a.Employee.EducationLevel).ToList();

            if (status == "viewed")
            {
                applications = applications.Where(a => a.ApplicationStatus.Name != Enums.ApplicationStatus.Applied.ToString()).ToList();
            }
            else if (status != null)
            {
                applications = applications.Where(a => a.ApplicationStatus.Name.ToLower().Equals(status.ToLower())).ToList();
            }
            var applicationDto = _mapper.Map<IEnumerable<CompanyApplicationDto>>(applications);

            return applicationDto.ToList();
        }

        // GET: api/Applications/5
        [HttpGet("{id}")]
        [Authorize(Roles = Authorization.Company)]
        public ActionResult<CompanyApplicationDto> GetApplication(int id)
        {
            var application = _context.Applications
                .Include(a => a.Employee)
                .Include(a => a.ApplicationStatus)
                .Include(a => a.Employee.User)
                .Include(a => a.Employee.Country)
                .Include(a => a.Employee.City)
                .Include(a => a.Employee.Skills)
                .Include(a => a.Employee.UserLanguages)
                .Include(a => a.Employee.EmployeeLinks)
                .Include(a => a.Employee.CareerLevel)
                .Include(a => a.Employee.EducationLevel)
                .FirstOrDefault(a => a.Id == id);

            if (application == null)
            {
                return BadRequest();
            }

            // update application Status if status = applied
            var job = _unitOfWork.Jobs.Get(application.JobId);
            if (application.ApplicationStatusId == _unitOfWork.ApplicationStatus.Find(s => s.Name == Enums.ApplicationStatus.Applied.ToString()).First().Id)
            {
                application.ApplicationStatusId = _unitOfWork.ApplicationStatus.Find(s => s.Name == Enums.ApplicationStatus.Viewed.ToString()).First().Id;
                job.ViewedApplications++;
                _unitOfWork.Application.Update(application);
                _unitOfWork.Jobs.Update(job);
                _unitOfWork.SaveChanges();
            }

            return _mapper.Map<CompanyApplicationDto>(application);
        }

        // PUT: api/Applications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //[Authorize(Roles = Authorization.Company)]
        //public async Task<IActionResult> PutApplication(int id, Application application)
        //{
        //    if (id != application.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(application).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ApplicationExists(id))
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

        //change Application status

        [HttpPut("status")]
        [Authorize(Roles = Authorization.Company)]
        public IActionResult ChangeApplicationStatus(ApplicationStatusDto applicationDto)
        {

            var application = _unitOfWork.Application.Find(a => a.Id == applicationDto.Id).FirstOrDefault();

            if (application == null)
            {
                return BadRequest();
            }

            var job = _unitOfWork.Jobs.Get(application.JobId);

            // Decrement old status count
            int oldStatusId = application.ApplicationStatusId;

            var applicationStatuses = _unitOfWork.ApplicationStatus.GetAll().ToList();

            //if (oldStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Viewed.ToString()).First().Id)
            //{
            //    job.ViewedApplications--;
            //}
            //else 
            if (oldStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.InConsideration.ToString()).First().Id)
            {
                job.InConsiderationApplications--;
            }
            else if (oldStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Rejected.ToString()).First().Id)
            {
                job.RejectedApplications--;
            }
            else if (oldStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Hired.ToString()).First().Id)
            {
                job.AcceptedApplications--;
            }

            // Update Status
            application.Status = applicationDto.Status;
            application.ApplicationStatusId = applicationStatuses.First(s => s.Name == applicationDto.Status).Id;

            // increment new status count
            if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Viewed.ToString()).First().Id)
            {
                job.ViewedApplications++;
            }
            else if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.InConsideration.ToString()).First().Id)
            {
                job.InConsiderationApplications++;
            }
            else if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Rejected.ToString()).First().Id)
            {
                job.RejectedApplications++;
            }
            else if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Hired.ToString()).First().Id)
            {
                job.AcceptedApplications++;
            }

            try
            {
                _unitOfWork.SaveChanges();
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

        //// POST: api/Applications
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Application>> PostApplication(Application application)
        //{
        //    _context.Applications.Add(application);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetApplication", new { id = application.Id }, application);
        //}

        //// DELETE: api/Applications/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteApplication(int id)
        //{
        //    var application = await _context.Applications.FindAsync(id);
        //    if (application == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Applications.Remove(application);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ApplicationExists(int id)
        {
            return _context.Applications.Any(e => e.Id == id);
        }
    }
}
