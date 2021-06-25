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

        public JobsController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _context = context;
        }


        // GET: api/Jobs
        [HttpGet]
        public ActionResult<IEnumerable<JobViewModel>> GetJobs()
        {
            // todo add company industry to job ( IT )
            var allJobData = _unitOfWork.Jobs.GetAllJobData();
            return Ok(_mapper.Map<IEnumerable<JobViewModel>>(allJobData));
        }

        [HttpGet("companyJobs")]
        [Authorize(Roles = "Company")]
        public async Task<ActionResult<IEnumerable<JobViewModel>>> GetCompanyJobs()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
                return BadRequest("Can't find User!\nlogin and try again.");

            var companyId = _unitOfWork.CompaniesManagers?.Find(c => c.UserId == user.Id).First().Id;

            if (companyId == null)
                return Unauthorized("Can't Access Company jobs with Employee Account!");

            var companyJobs = _unitOfWork.Jobs.GetAllJobData().Where(c => c.CompanyId == companyId);
            return Ok(_mapper.Map<IEnumerable<JobViewModel>>(companyJobs));
        }
        [HttpGet("companyJobsData")]
        [Authorize(Roles = "Company")]
        public async Task<ActionResult<IEnumerable<CompanyJobDto>>> GetCompanyJobsData()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            var companyJobs = _context.Jobs
                .Include(a => a.Skills)
                    .ThenInclude(a => a.Skills)
                .Include(a => a.JobDetails)
                .Include(a => a.JobDetails.CareerLevel)
                .Include(a => a.JobDetails.JobCategory)
                .Include(a => a.JobDetails.EducationLevel)
                .Include(a => a.JobDetails.SalaryCurrency)
                .Include(a => a.JobDetails.SalaryRate)
                .Where(c => c.CompanyId == companyId);
            var company = _mapper.Map<IEnumerable<CompanyJobDto>>(companyJobs);
            return Ok(company);
        }

        //[HttpGet("SeedAngular")]
        //public ActionResult<SeedAngular> GetAllConstants()
        //{
        //    SeedAngular s = new SeedAngular()
        //    {
        //        jobTypes = _DB.JobTypes.ToList(),
        //        jobCategories = _DB.JobCategories.ToList(),
        //        countries = _DB.Countries.ToList(),
        //        cities = _DB.Cities.ToList(),
        //        Currencies = _DB.Currencies.ToList(),
        //        salaryRates = _DB.SalaryRates.ToList(),
        //        Skills = _DB.Skills.ToList(),
        //        careerLevels = _DB.CareerLevels.ToList(),
        //        EducationLevels = _DB.EducationLevels.ToList()
        //    };
        //    return s;
        //}

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public ActionResult<CompanyJobDto> GetJob(int id)
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
                .FirstOrDefault(j => j.Id == id);

            if (job == null)
            {
                return NotFound();
            }

            return _mapper.Map<CompanyJobDto>(job);
        }


        [HttpGet("Search/{term}/{loc}")]
        public ActionResult<IEnumerable<JobViewModel>> Search(string term, string loc)
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
        [Authorize(Roles = "Company")]
        public IActionResult PutJob(int id, [FromBody] PostJobDto postedjob)
        {
            postedjob.Id = id;

            var oldJob = _context.Jobs.Include(j => j.JobDetails).Include(j => j.Skills).FirstOrDefault(j => j.Id == id);
            postedjob.IsOpen = true;
            postedjob.JobDetails.Id = oldJob.JobDetails.Id;
            _mapper.Map(postedjob, oldJob);

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
        [Authorize(Roles = "Company")]
        public IActionResult CloseJob([FromBody] int id)
        {
            var job = _unitOfWork.Jobs.Get(id);


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

            if (user == null)
                return BadRequest("Can't find User!");

            var companyId = _unitOfWork.CompaniesManagers?.Find(c => c.UserId == user.Id).FirstOrDefault().Id;

            if (companyId == null)
                return BadRequest("Error Occured!\nTry Again.");

            job.CompanyId = companyId.Value;

            job.TotalClicks = 1;
            _unitOfWork.Jobs.Add(job);
            _unitOfWork.SaveChanges();
            return Ok(job);
        }

        //// DELETE: api/Jobs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteJob(int id)
        //{
        //    var job = await _context.Jobs.FindAsync(id);
        //    if (job == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Jobs.Remove(job);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool JobExists(int id)
        {
            return _context.Jobs.Any(e => e.Id == id);
        }
    }
}
