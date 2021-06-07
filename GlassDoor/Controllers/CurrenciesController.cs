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
    public class CurrenciesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CurrenciesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Currencies
        [HttpGet]
        public ActionResult<IEnumerable<CurrencyDto>> GetCurrencies()
        {
            return Ok(_mapper.Map<IEnumerable<CurrencyDto>>(_unitOfWork.Currency.GetAll()));
        }

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public ActionResult<CurrencyDto> GetCurrency(int id)
        {
            var currency = _mapper.Map<CurrencyDto>(_unitOfWork.Currency.Get(id));

            if (currency == null)
            {
                return NotFound();
            }

            return currency;
        }

        //// PUT: api/Currencies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutCurrency(int id, Currency currency)
        {
            if (id != currency.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Currency.Update(currency);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Currency> PostCurrency(Currency currency)
        {
            _unitOfWork.Currency.Add(currency);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetCurrency", new { id = currency.Id }, currency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCurrency(int id)
        {
            var currency = _unitOfWork.Currency.Get(id);
            if (currency == null)
            {
                return NotFound();
            }

            _unitOfWork.Currency.Remove(currency);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool CurrencyExists(int id)
        {
            return _unitOfWork.Currency.Get(id) != null;
        }
    }
}
