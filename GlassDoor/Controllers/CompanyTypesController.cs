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
    public class CompanyTypesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CompanyTypesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/CompanyTypes
        [HttpGet]
        public ActionResult<IEnumerable<CompanyTypeDto>> GetCompanyTypes()
        {
            return Ok(_mapper.Map<IEnumerable<CompanyTypeDto>>(_unitOfWork.CompanyType.GetAll()));
        }

        // GET: api/CompanyTypes/5
        [HttpGet("{id}")]
        public ActionResult<CompanyTypeDto> GetCompanyType(int id)
        {
            var companyType = _mapper.Map<CompanyTypeDto>(_unitOfWork.CompanyType.Get(id));

            if (companyType == null)
            {
                return NotFound();
            }

            return companyType;
        }

        //// PUT: api/CompanyTypes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCompanyType(int id, CompanyType companyType)
        //{
        //    if (id != companyType.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _unitOfWork.CompanyType.Update(companyType);

        //    try
        //    {
        //        _unitOfWork.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CompanyTypeExists(id))
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

        ////// POST: api/CompanyTypes
        ////// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<CompanyType>> PostCompanyType(CompanyType companyType)
        //{
        //    _unitOfWork.CompanyType.Add(companyType);
        //    _unitOfWork.SaveChanges();

        //    return CreatedAtAction("GetCompanyType", new { id = companyType.Id }, companyType);
        //}

        //// DELETE: api/CompanyTypes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCompanyType(int id)
        //{
        //    var companyType = _unitOfWork.CompanyType.Get(id);
        //    if (companyType == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.CompanyType.Remove(companyType);
        //    _unitOfWork.SaveChanges();

        //    return NoContent();
        //}

        private bool CompanyTypeExists(int id)
        {
            return _unitOfWork.CompanyType.Get(id) != null;
        }
    }
}
