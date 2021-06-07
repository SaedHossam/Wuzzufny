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
    public class SkillsController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        public SkillsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Skills
        [HttpGet]
        public ActionResult<IEnumerable<SkillsDto>> GetSkills()
        {
            return Ok(_mapper.Map<IEnumerable<SkillsDto>>(_unitOfWork.Skills.GetAll()));
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public ActionResult<SkillsDto> GetSkill(int id)
        {
            var skill = _mapper.Map<SkillsDto>(_unitOfWork.Skills.Get(id));

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutSkill(int id, SkillsDto skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Skills.Update(_mapper.Map<Skill>(skill));

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Skill> PostSkill(SkillsDto skill)
        {
            _unitOfWork.Skills.Add(_mapper.Map<Skill>(skill));
            _unitOfWork.SaveChanges();

            return CreatedAtAction("GetSkill", new { id = skill.Id }, skill);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _unitOfWork.Skills.Get(id);
            if (skill == null)
            {
                return NotFound();
            }

            _unitOfWork.Skills.Remove(skill);
            _unitOfWork.SaveChanges();

            return NoContent();
        }

        private bool SkillExists(int id)
        {
            return _unitOfWork.Skills.Get(id) != null;
        }
    }
}
