using AutoMapper;
using DAL;
using DAL.Models;
using GlassDoor.Constants;
using GlassDoor.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.Controllers
{
    // TODO: add get application by id method
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
        // this methods takes no paramater
        // it returns all user applications
        [HttpGet]
        [Authorize(Roles = Authorization.Employee)]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetApplications()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            
            if (user == null)
                return BadRequest("User Not Found!");

            var userId = user.Id;
            var employee = _unitOfWork.Employees.Find(a => a.UserId == userId).FirstOrDefault();
            if (employee == null)
                return BadRequest("Employee Not Found!");

            var employeeApplications = _unitOfWork.Application.GetEmployeeApplications(employee.Id);
            return Ok(_mapper.Map<IEnumerable<ApplicationDto>>(employeeApplications));

        }


        // Apply to job
        // summary:
        // this method takes job id as paramater
        // Check if user didn't apply before or withdraw his previous application
        // create new application
        // set apply date to DateTime.Now()
        // set IsArchived, IsViewed, and IsWithdrawn to false
        // TODO: update job application (++)
        [HttpPost]
        [Authorize(Roles = Authorization.Employee)]
        public async Task<ActionResult<ApplicationDto>> PostApplication([FromBody] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return BadRequest("User not Found!");
            var userId = user.Id;
            var empId = _unitOfWork.Employees.Find(a => a.UserId == userId).FirstOrDefault().Id;
            var application = _unitOfWork.Application.Find(a => a.JobId == id && a.EmployeeId == empId).FirstOrDefault();
            if (application == null || application.IsWithdrawn == true)
            {
                Application app = new()
                {
                    JobId = id,
                    ApplyDate = DateTime.Now,
                    IsArchived = false,
                    IsViewed = false,
                    IsWithdrawn = false,
                    EmployeeId = empId
                };
                _unitOfWork.Application.Add(app);
                _unitOfWork.SaveChanges();
                return Ok(app);
            }
            else
            {
                return BadRequest("You already applied!");
            }
        }

        // Summry:
        // this method takes application id, and bool value archived as paramter 
        // it checks if application is wirthdrawn then it return error
        // if archived = true, then archive application, and update archive date
        // else unarchive application, and set date to null
        [HttpPut("{id}")]
        [Authorize(Roles = Authorization.Employee)]
        //public IActionResult PutApp(int id, bool archived)
        public IActionResult PutApp([FromBody] ArchiveApplicationDto archiveApplication)
        {
            var application = _unitOfWork.Application.Find(a => a.Id == archiveApplication.Id).FirstOrDefault();
            if (application == null)
                return BadRequest("Cann't Find Application!");

            if (application.IsWithdrawn == true)
                return BadRequest("This application is withdrawn.");

            application.IsArchived = archiveApplication.Archived;
            application.ArchiveDate = archiveApplication.Archived ? DateTime.Now : null;
            _unitOfWork.Application.Update(application);
            _unitOfWork.SaveChanges();
            return Ok(application);
        }

        // summary
        // this method takes application id as paramter 
        // it checks if application exists or if its already withdrawn then it return error
        // else it withdraw application
        // TODO: update job application count
        [HttpPut("withdraw/{id}")]
        [Authorize(Roles = Authorization.Employee)]
        public IActionResult PutApplication([FromBody] int id)
        {
            var application = _unitOfWork.Application.Find(a => a.Id == id).FirstOrDefault();
            if (application == null)
                return BadRequest("Cann't Find Application!");

            if (application.IsWithdrawn == true)
                return BadRequest("This application is withdrawn.");

            application.IsWithdrawn = true;
            application.WithDrawDate = DateTime.Now;
            _unitOfWork.Application.Update(application);
            _unitOfWork.SaveChanges();
            return Ok(application);
        }
    }
}
