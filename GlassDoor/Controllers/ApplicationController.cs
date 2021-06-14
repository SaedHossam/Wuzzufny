using AutoMapper;
using DAL;
using DAL.Models;
using GlassDoor.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationController(IMapper mapper, UserManager<ApplicationUser> userManager, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        // GET: api/Application
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplications()
        {
            var allApps = _unitOfWork.Application.GetAll().Where(a => a.IsArchived == false && a.IsWithdrawn == false);
            return Ok(_mapper.Map<IEnumerable<ApplicationDto>>(allApps));
        }


        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> PostApplication([FromBody] ApplicationDto applied)
        {
            if (applied == null || !ModelState.IsValid)
                return BadRequest();

            var app = _mapper.Map<Application>(applied);
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var userId = user.Id;
            var empId = _unitOfWork.Employees.Find(a => a.UserId == userId).FirstOrDefault().Id;
            app.ApplyDate = DateTime.Now;
            app.IsArchived = false;
            app.IsViewed = false;
            app.IsWithdrawn = false;
            app.EmployeeId = empId;
            _unitOfWork.Application.Add(app);
            _unitOfWork.SaveChanges();
            return Ok(app);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutApp(int id, bool arc)
        {
            var app = _unitOfWork.Application.Find(a => a.Id == id).FirstOrDefault();
            var app1 = _mapper.Map<Application>(app);

            if (arc == true)
            {
                app1.IsArchived = true;
                app1.ArchiveDate = DateTime.Now;
                _unitOfWork.Application.Update(app1);
                _unitOfWork.SaveChanges();
                return Ok(app);
            }
            if( arc == false)
            {
                app.IsArchived = false;
                app.ArchiveDate = null;
                _unitOfWork.Application.Update(app1);
                _unitOfWork.SaveChanges();
                return Ok(app);
            }
            return Ok(app);


        }

    }
}
