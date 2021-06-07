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
    public class CareerLevelsController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;


        public CareerLevelsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/CareerLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CareerLevelDto>>> GetCareerLevels()
        {
            //return await _context.CareerLevels.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<CareerLevelDto>>(_unitOfWork.CareerLevel.GetAll()));
        }

        // GET: api/CareerLevels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CareerLevelDto>> GetCareerLevel(int id)
        {
            var careerLevel = _mapper.Map<CareerLevelDto>(_unitOfWork.CareerLevel.Get(id));

            if (careerLevel == null)
            {
                return NotFound();
            }

            return careerLevel;
        }

        // PUT: api/CareerLevels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCareerLevel(int id, CareerLevelDto careerLevelDto)
        {
            if (id != careerLevelDto.Id)
            {
                return BadRequest();
            }

            var companySize = _mapper.Map<CareerLevel>(careerLevelDto);

            _unitOfWork.CareerLevel.Update(companySize);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerLevelExists(id))
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

        // POST: api/CareerLevels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CareerLevelDto>> PostCareerLevel(CareerLevelDto careerLevelDto)
        {
            var careerLevel = _mapper.Map<CareerLevel>(careerLevelDto);
            _unitOfWork.CareerLevel.Add(careerLevel);
            _unitOfWork.SaveChanges();
            return CreatedAtAction("GetCareerLevel", new { id = careerLevel.Id }, careerLevel);
        }

        // DELETE: api/CareerLevels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCareerLevel(int id)
        {
            var careerLevel = _unitOfWork.CareerLevel.Get(id);
            if (careerLevel == null)
            {
                return NotFound();
            }

            _unitOfWork.CareerLevel.Remove(careerLevel);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool CareerLevelExists(int id)
        {
            return _unitOfWork.CareerLevel.Get(id) != null;
        }
    }
}
