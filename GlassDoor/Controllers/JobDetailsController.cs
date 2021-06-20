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
using Microsoft.AspNetCore.Identity;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public JobDetailsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetails>>> GetJobsDetails()
        {
            return await _context.JobsDetails.ToListAsync();
        }

        [HttpGet("GetJobDetails/{id}")]
        public async Task<ActionResult<JobDetailsDto>> GetJobDetails(int id)
        {
            // todo: add number of vacancies, company ID, hasApplication: bool, companyLogo, each skill => add is available in candidate: bool
            //var job = _unitOfWork.Jobs.GetJobById(id);
            var details = _mapper.Map<JobDetailsDto>(_unitOfWork.JobsDetails.GetJobDetails(id));

            //var jobDetails = _unitOfWork.JobsDetails.GetJobDetails(job.Id);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            var empId = _unitOfWork.Employees.Find(a => a.UserId == userId).FirstOrDefault().Id;
            var emp = _unitOfWork.Employees.GetEmployeeSkills(empId);
            var userSkills = emp.Skills;
            foreach (var skill in details.SkillsNames)
            {
                skill.Match = userSkills.FirstOrDefault(s => s.Id == skill.Id) != null;
            }
            if (details == null)
                return NotFound();
            details.Applied = _unitOfWork.Application.Find(a => a.JobId == details.JobId && a.EmployeeId == empId).FirstOrDefault() != null;
            return  Ok(_mapper.Map<JobDetailsDto>(details));

        }
        // PUT: api/JobDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobDetails(int id, JobDetails jobDetails)
        {
            if (id != jobDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(jobDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailsExists(id))
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

        // POST: api/JobDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JobDetails>> PostJobDetails(JobDetails jobDetails)
        {
            _context.JobsDetails.Add(jobDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobDetails", new { id = jobDetails.Id }, jobDetails);
        }

        // DELETE: api/JobDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobDetails(int id)
        {
            var jobDetails = await _context.JobsDetails.FindAsync(id);
            if (jobDetails == null)
            {
                return NotFound();
            }

            _context.JobsDetails.Remove(jobDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobDetailsExists(int id)
        {
            return _context.JobsDetails.Any(e => e.Id == id);
        }
    }
}
