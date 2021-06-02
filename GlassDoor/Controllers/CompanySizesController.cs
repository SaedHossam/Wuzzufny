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
    public class CompanySizesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CompanySizesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/CompanySizes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanySizeDto>>> GetCompanySizes()
        {
            return Ok(_mapper.Map<IEnumerable<CompanySizeDto>>(_unitOfWork.CompanySize.GetAll()));
        }

        // GET: api/CompanySizes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanySizeDto>> GetCompanySize(int id)
        {
            var companySize = _unitOfWork.CompanySize.Get(id);

            if (companySize == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CompanySizeDto>(companySize));
        }

        // PUT: api/CompanySizes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanySize(int id, CompanySizeDto companySizeDto)
        {
            if (id != companySizeDto.Id)
            {
                return BadRequest();
            }

            var companySize = _mapper.Map<CompanySize>(companySizeDto);

            _unitOfWork.CompanySize.Update(companySize);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanySizeExists(id))
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

        // POST: api/CompanySizes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanySizeDto>> PostCompanySize(CompanySizeCreateDto companySizeDto)
        {
            var companySize = _mapper.Map<CompanySize>(companySizeDto);

            _unitOfWork.CompanySize.Add(companySize);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetCompanySize", new { id = companySize.Id }, _mapper.Map<CompanySizeDto>(companySize));
        }

        // DELETE: api/CompanySizes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanySize(int id)
        {
            var companySize = _unitOfWork.CompanySize.Get(id);
            if (companySize == null)
            {
                return NotFound();
            }

            _unitOfWork.CompanySize.Remove(companySize);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool CompanySizeExists(int id)
        {
            return _unitOfWork.CompanySize.Get(id) != null;
        }
    }
}
