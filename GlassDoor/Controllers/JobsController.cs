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
using Microsoft.AspNetCore.Identity;

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
        public JobsController( IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,ApplicationDbContext DB)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _context = DB;
            _DB = DB;
        }

        // GET: api/Jobs
        [HttpGet]
        public  ActionResult<IEnumerable<Job>> GetJobs()
        {
            return  _unitOfWork.Jobs.GetAll().ToList();
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
        public async Task<ActionResult<Job>> GetJob(int id)
        {
            var job = await _context.Jobs.FindAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
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
            var oldJob = _context.Jobs.Include(j => j.JobDetails).FirstOrDefault(j => j.Id == id);
            job.JobDetails.Id = oldJob.JobDetails.Id;
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

        // POST: api/Jobs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostJobDto>> PostJob([FromBody]PostJobDto postedjob)
        {
            if (postedjob == null || !ModelState.IsValid) 
                return BadRequest();

            var job = _mapper.Map<Job>(postedjob);
    
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
