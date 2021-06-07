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
    public class SalaryRatesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public SalaryRatesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/SalaryRates
        [HttpGet]
        public ActionResult<IEnumerable<SalaryRateDto>> GetSalaryRates()
        {
            return Ok(_mapper.Map<IEnumerable<SalaryRateDto>>(_unitOfWork.SalaryRate.GetAll()));
        }

        // GET: api/SalaryRates/5
        [HttpGet("{id}")]
        public ActionResult<SalaryRateDto> GetSalaryRate(int id)
        {
            var salaryRate = _mapper.Map<SalaryRateDto>(_unitOfWork.SalaryRate.Get(id));

            if (salaryRate == null)
            {
                return NotFound();
            }

            return salaryRate;
        }

        // PUT: api/SalaryRates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSalaryRate(int id, SalaryRateDto salaryRate)
        {
            if (id != salaryRate.Id)
            {
                return BadRequest();
            }

            _unitOfWork.SalaryRate.Update(_mapper.Map<SalaryRate>(salaryRate));

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryRateExists(id))
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

        // POST: api/SalaryRates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<SalaryRate> PostSalaryRate(SalaryRateDto salaryRate)
        {
            _unitOfWork.SalaryRate.Add(_mapper.Map<SalaryRate>(salaryRate));
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetSalaryRate", new { id = salaryRate.Id }, salaryRate);
        }

        // DELETE: api/SalaryRates/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSalaryRate(int id)
        {
            var salaryRate = _unitOfWork.SalaryRate.Get(id);
            if (salaryRate == null)
            {
                return NotFound();
            }

            _unitOfWork.SalaryRate.Remove(salaryRate);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool SalaryRateExists(int id)
        {
            return _unitOfWork.SalaryRate.Get(id) != null;
        }
    }
}
