using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using GlassDoor.ViewModels;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public JobTypesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/JobTypes
        [HttpGet]
        public ActionResult<IEnumerable<JobTypeDto>> GetJobTypes()
        {
            return Ok(_mapper.Map<IEnumerable<JobTypeDto>>(_unitOfWork.JobType.GetAll()));
        }

        // GET: api/JobTypes/5
        [HttpGet("{id}")]
        public ActionResult<JobTypeDto> GetJobType(int id)
        {
            var jobType = _mapper.Map<JobTypeDto>(_unitOfWork.JobType.Get(id));

            if (jobType == null)
            {
                return NotFound();
            }

            return jobType;
        }

        //// PUT: api/JobTypes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutJobType(int id, JobType jobType)
        //{
        //    if (id != jobType.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _unitOfWork.JobType.Update(jobType);

        //    try
        //    {
        //        _unitOfWork.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JobTypeExists(id))
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

        //// POST: api/JobTypes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<JobType>> PostJobType(JobType jobType)
        //{
        //    _unitOfWork.JobType.Add(jobType);
        //    _unitOfWork.SaveChanges();

        //    return CreatedAtAction("GetJobType", new { id = jobType.Id }, jobType);
        //}

        //// DELETE: api/JobTypes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteJobType(int id)
        //{
        //    var jobType = _unitOfWork.JobType.Get(id);
        //    if (jobType == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.JobType.Remove(jobType);
        //    _unitOfWork.SaveChanges();

        //    return NoContent();
        //}

        private bool JobTypeExists(int id)
        {
            return _unitOfWork.CompanyType.Get(id) != null;
        }
    }
}
