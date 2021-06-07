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
    public class EducationLevelsController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public EducationLevelsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/EducationLevels
        [HttpGet]
        public ActionResult<IEnumerable<EducationLevelDto>> GetEducationLevels()
        {
            return Ok(_mapper.Map<IEnumerable<EducationLevelDto>>(_unitOfWork.EducationLevel.GetAll()));
        }

        // GET: api/EducationLevels/5
        [HttpGet("{id}")]
        public ActionResult<EducationLevelDto> GetEducationLevel(int id)
        {
            var educationLevel = _mapper.Map<EducationLevelDto>(_unitOfWork.EducationLevel.Get(id));

            if (educationLevel == null)
            {
                return NotFound();
            }

            return educationLevel;
        }

        //PUT: api/EducationLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutEducationLevel(int id, EducationLevel educationLevel)
        {
            if (id != educationLevel.Id)
            {
                return BadRequest();
            }

            _unitOfWork.EducationLevel.Update(educationLevel);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationLevelExists(id))
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

        //POST: api/EducationLevels
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<EducationLevelDto> PostEducationLevel(EducationLevelDto educationLevel)
        {
            // Todo: Check this api, it returns EducationLevel as EducationLevelDto
            _unitOfWork.EducationLevel.Add(_mapper.Map<EducationLevel>(educationLevel));
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetEducationLevel", new { id = educationLevel.Id }, educationLevel);
        }

        //DELETE: api/EducationLevels/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEducationLevel(int id)
        {
            var educationLevel = _unitOfWork.EducationLevel.Get(id);
            if (educationLevel == null)
            {
                return NotFound();
            }

            _unitOfWork.EducationLevel.Remove(educationLevel);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool EducationLevelExists(int id)
        {
            return _unitOfWork.EducationLevel.Get(id) != null;
        }
    }
}
