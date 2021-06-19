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
    public class JobCategoriesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public JobCategoriesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/JobCategories
        [HttpGet]
        public ActionResult<IEnumerable<JobCategoryDto>> GetJobCategories()
        {
            return Ok(_mapper.Map<IEnumerable<JobCategoryDto>>(_unitOfWork.JobCategory.GetAll()));
        }

        // GET: api/JobCategories/5
        [HttpGet("{id}")]
        public ActionResult<JobCategoryDto> GetJobCategory(int id)
        {
            var jobCategory = _mapper.Map<JobCategoryDto>(_unitOfWork.JobCategory.Get(id));

            if (jobCategory == null)
            {
                return NotFound();
            }

            return jobCategory;
        }

        //// PUT: api/JobCategories/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public IActionResult PutJobCategory(int id, JobCategory jobCategory)
        //{
        //    if (id != jobCategory.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _unitOfWork.JobCategory.Update(jobCategory);

        //    try
        //    {
        //        _unitOfWork.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!JobCategoryExists(id))
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

        //// POST: api/JobCategories
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public ActionResult<JobCategory> PostJobCategory(JobCategory jobCategory)
        //{
        //    _unitOfWork.JobCategory.Add(jobCategory);
        //    _unitOfWork.SaveChanges();

        //    return CreatedAtAction("GetJobCategory", new { id = jobCategory.Id }, jobCategory);
        //}

        //// DELETE: api/JobCategories/5
        //[HttpDelete("{id}")]
        //public IActionResult DeleteJobCategory(int id)
        //{
        //    var jobCategory = _unitOfWork.JobCategory.Get(id);
        //    if (jobCategory == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.JobCategory.Remove(jobCategory);
        //    _unitOfWork.SaveChanges();

        //    return NoContent();
        //}

        private bool JobCategoryExists(int id)
        {
            return _unitOfWork.JobCategory.Get(id) != null;
        }
    }
}
