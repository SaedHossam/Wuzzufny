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
    public class CitiesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CitiesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            return Ok(_mapper.Map<IEnumerable<CityDto>>(_unitOfWork.City.GetAll()));
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(int id)
        {
            var city = _unitOfWork.City.Get(id);

            if (city == null)
            {
                return NotFound();
            }

            return city;
        }

        // PUT: api/Cities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(int id, City city)
        {
            if (id != city.Id)
            {
                return BadRequest();
            }

            _unitOfWork.City.Update(city);
            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        //// POST: api/Cities
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            _unitOfWork.City.Add(city);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetCity", new { id = city.Id }, city);
        }

        //// DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = _unitOfWork.City.Get(id);
            if (city == null)
            {
                return NotFound();
            }

            _unitOfWork.City.Remove(city);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool CityExists(int id)
        {
            return _unitOfWork.City.Get(id) != null;
        }

        // Todo: Get All Cities in Country

    }
}
