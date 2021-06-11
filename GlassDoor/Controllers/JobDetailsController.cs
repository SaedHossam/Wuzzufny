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
    public class JobDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JobDetailsController(ApplicationDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/JobDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDetails>>> GetJobsDetails()
        {
            return await _context.JobsDetails.ToListAsync();
        }

        [HttpGet("GetJobDetails/{id}")]
        public async Task<ActionResult<JobDetails>> GetJobDetails(int id)
        {
            // todo: add number of vacancies, company ID, hasApplication: bool, companyLogo, each skill => add is available in candidate: bool
            //var job = _unitOfWork.Jobs.GetJobById(id);
            var details = _unitOfWork.JobsDetails.GetJobDetails(id);

            //var jobDetails = _unitOfWork.JobsDetails.GetJobDetails(job.Id);

            if (details == null)
                return NotFound();

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
