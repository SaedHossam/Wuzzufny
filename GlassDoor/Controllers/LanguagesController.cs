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
    public class LanguagesController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public LanguagesController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Languages
        [HttpGet]
        public ActionResult<IEnumerable<LanguageDto>> GetLanguages()
        {
            return Ok(_mapper.Map<IEnumerable<LanguageDto>>(_unitOfWork.Language.GetAll()));
        }

        // GET: api/Languages/5
        [HttpGet("{id}")]
        public ActionResult<LanguageDto> GetLanguage(int id)
        {
            var language = _mapper.Map<LanguageDto>(_unitOfWork.Language.Get(id));

            if (language == null)
            {
                return NotFound();
            }

            return language;
        }

        // PUT: api/Languages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutLanguage(int id, Language language)
        {
            if (id != language.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Language.Update(language);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/Languages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Language> PostLanguage(Language language)
        {
            _unitOfWork.Language.Add(language);
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetLanguage", new { id = language.Id }, language);
        }

        // DELETE: api/Languages/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLanguage(int id)
        {
            var language = _unitOfWork.Language.Get(id);
            if (language == null)
            {
                return NotFound();
            }

            _unitOfWork.Language.Remove(language);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool LanguageExists(int id)
        {
            return _unitOfWork.Language.Get(id) != null;
        }
    }
}
