using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using GlassDoor.ViewModels;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyIndustriesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CompanyIndustriesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/CompanyIndustries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyIndustryDto>>> GetCompanyIndustries()
        {
            return Ok(_mapper.Map<IEnumerable<CompanyIndustryDto>>(_unitOfWork.CompanyIndustry.GetAll()));
        }

        // ToDo change return type(use viewModels)
        // GET: api/CompanyIndustries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyIndustry>> GetCompanyIndustry(int id)
        {
            var companyIndustry = _unitOfWork.CompanyIndustry.Get(id);

            if (companyIndustry == null)
            {
                return NotFound();
            }

            return companyIndustry;
        }

        // PUT: api/CompanyIndustries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyIndustry(int id, CompanyIndustry companyIndustry)
        {
            if (id != companyIndustry.Id)
            {
                return BadRequest();
            }

            _unitOfWork.CompanyIndustry.Update(companyIndustry);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyIndustryExists(id))
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

        // POST: api/CompanyIndustries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyIndustry>> PostCompanyIndustry(CompanyIndustry companyIndustry)
        {
            _unitOfWork.CompanyIndustry.Add(companyIndustry);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetCompanyIndustry", new { id = companyIndustry.Id }, companyIndustry);
        }

        // DELETE: api/CompanyIndustries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyIndustry(int id)
        {
            var companyIndustry = _unitOfWork.CompanyIndustry.Get(id);
            if (companyIndustry == null)
            {
                return NotFound();
            }

            _unitOfWork.CompanyIndustry.Remove(companyIndustry);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool CompanyIndustryExists(int id)
        {
            return _unitOfWork.CompanyIndustry.Get(id) != null;
        }
    }
}
