using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserLanguagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/UserLanguages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserLanguage>>> GetUserLanguages()
        {
            return await _context.UserLanguages.ToListAsync();
        }

        // GET: api/UserLanguages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserLanguage>> GetUserLanguage(int id)
        {
            var userLanguage = await _context.UserLanguages.FindAsync(id);

            if (userLanguage == null)
            {
                return NotFound();
            }

            return userLanguage;
        }

        //// PUT: api/UserLanguages/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserLanguage(int id, UserLanguage userLanguage)
        //{
        //    if (id != userLanguage.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userLanguage).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserLanguageExists(id))
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

        //// POST: api/UserLanguages
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserLanguage>> PostUserLanguage(UserLanguage userLanguage)
        //{
        //    _context.UserLanguages.Add(userLanguage);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserLanguage", new { id = userLanguage.Id }, userLanguage);
        //}

        //// DELETE: api/UserLanguages/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserLanguage(int id)
        //{
        //    var userLanguage = await _context.UserLanguages.FindAsync(id);
        //    if (userLanguage == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserLanguages.Remove(userLanguage);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool UserLanguageExists(int id)
        {
            return _context.UserLanguages.Any(e => e.Id == id);
        }
    }
}
