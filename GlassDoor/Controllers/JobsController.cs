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
using Microsoft.AspNetCore.Identity;
using glassDoor.ViewModels;
using DAL.Constants;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _DB;
        public JobsController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ApplicationDbContext DB)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _context = DB;
            _DB = DB;
        }


        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobViewModel>>> GetJobs()
        {
            var allJobData = _unitOfWork.Jobs.GetAllJobData();
            return Ok(_mapper.Map<IEnumerable<JobViewModel>>(allJobData));
        }

        [HttpGet("companyJobs")]
        public async Task<ActionResult<IEnumerable<JobViewModel>>> GetCompanyJobs()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            var companyJobs = _unitOfWork.Jobs.GetAllJobData().Where(c => c.CompanyId == companyId);
            return Ok(_mapper.Map<IEnumerable<JobViewModel>>(companyJobs));
        }
        [HttpGet("companyJobsData")]
        public async Task<ActionResult<IEnumerable<CompanyJobDto>>> GetCompanyJobsData()
         {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            var companyJobs = _context.Jobs
                .Include(a=>a.Skills)
                    .ThenInclude(a=>a.Skills)
                .Include(a=>a.JobDetails)
                .Include(a => a.JobDetails.CareerLevel)
                .Include(a => a.JobDetails.JobCategory)
                .Include(a => a.JobDetails.EducationLevel)
                .Include(a => a.JobDetails.SalaryCurrency)
                .Include(a => a.JobDetails.SalaryRate)
                .Where(c => c.CompanyId == companyId);
            var company = _mapper.Map<IEnumerable<CompanyJobDto>>(companyJobs);
            return Ok(company);
        }

        [HttpGet("SeedAngular")]
        public ActionResult<SeedAngular> GetAllConstants()
        {
            SeedAngular s = new SeedAngular()
            {
                jobTypes = _DB.JobTypes.ToList(),
                jobCategories = _DB.JobCategories.ToList(),
                countries = _DB.Countries.ToList(),
                cities = _DB.Cities.ToList(),
                Currencies = _DB.Currencies.ToList(),
                salaryRates = _DB.SalaryRates.ToList(),
                Skills = _DB.Skills.ToList(),
                careerLevels = _DB.CareerLevels.ToList(),
                EducationLevels = _DB.EducationLevels.ToList()
            };
            return s;
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyJobDto>> GetJob(int id)
        {
            var job = _context.Jobs
                .Include(a => a.Skills)
                    .ThenInclude(a => a.Skills)
                .Include(a => a.JobDetails)
                .Include(a => a.JobDetails.CareerLevel)
                .Include(a => a.JobDetails.JobCategory)
                .Include(a => a.JobDetails.EducationLevel)
                .Include(a => a.JobDetails.SalaryCurrency)
                .Include(a => a.JobDetails.SalaryRate)
                .Where(j => j.Id == id)
                .FirstOrDefault();

            if (job == null)
            {
                return NotFound();
            }

            return _mapper.Map<CompanyJobDto>(job);
        }


        [HttpGet("Search/{term}/{loc}")]
        public async Task<ActionResult<IEnumerable<JobViewModel>>> Search(string term, string loc)
        {
            var res = _unitOfWork.Jobs.GetAllJobData().Where(i => i.Title.Contains(term, StringComparison.InvariantCultureIgnoreCase)
                || i.Company.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase)
                || i.Country.Name.Contains(loc, StringComparison.InvariantCultureIgnoreCase)
                || i.City.Name.Contains(loc, StringComparison.InvariantCultureIgnoreCase)).ToList();
            return Ok(_mapper.Map<IEnumerable<JobViewModel>>(res));

        }

        // PUT: api/Jobs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, [FromBody] PostJobDto postedjob)
        {
            if (id != postedjob.Id)
            {
                return BadRequest();
            }

            var job = _mapper.Map<Job>(postedjob);
            var oldJob = _context.Jobs.Include(j => j.JobDetails).Include(j=>j.Skills).FirstOrDefault(j => j.Id == id);
            job.JobDetails.Id = oldJob.JobDetails.Id;
            job.CompanyId = oldJob.CompanyId;
            //update job
            _mapper.Map<Job, Job>(job, oldJob);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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

        //change job status to close
        [HttpPut("closeJob")]
        public async Task<IActionResult> closeJob([FromBody] int id)
        {
            Job? job = _unitOfWork.Jobs.Get(id);

            //var job = _context.Jobs.FirstOrDefault(j => j.Id == id);

            if (job == null)
            {

                return BadRequest();
            }

            job.IsOpen = false;

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
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
        // POST: api/Jobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Company")]
        public async Task<ActionResult<PostJobDto>> PostJob([FromBody] PostJobDto postedjob)
        {
            if (postedjob == null || !ModelState.IsValid)
                return BadRequest();

            var job = _mapper.Map<Job>(postedjob);
            job.IsOpen = true;
            
            
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            job.CompanyId = companyId;
            _unitOfWork.Jobs.Add(job);
            _unitOfWork.SaveChanges();
            return Ok(job);
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
