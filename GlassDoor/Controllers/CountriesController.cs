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
    public class CountriesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CountriesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetCountries()
        {
            return Ok(_mapper.Map<IEnumerable<CountryDto>>(_unitOfWork.Country.GetAll()));
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = _mapper.Map <CountryDto>(_unitOfWork.Country.Get(id));
            var cities = _mapper.Map<IEnumerable<CityDto>>(_unitOfWork.City.GetAll().Where(c => c.CountryId == id).ToList());
            if (country == null)
            {
                return NotFound();
            }
            country.Cities = cities;
            return country;
        }

        //// PUT: api/Countries/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Country.Update(country);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        //// POST: api/Countries
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _unitOfWork.Country.Add(country);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = _unitOfWork.Country.Get(id);
            if (country == null)
            {
                return NotFound();
            }

            _unitOfWork.Country.Remove(country);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _unitOfWork.Country.Get(id) != null ;
        }
    }
}
