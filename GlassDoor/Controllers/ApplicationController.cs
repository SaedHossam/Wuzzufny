using AutoMapper;
using DAL;
using DAL.Models;
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
        // [Authorize("Employee")]
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

        /// <summary>
        /// this method return all Employee Archived Application
        /// </summary>
        /// <returns></returns>
        [HttpGet("archived")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<IEnumerable<ApplicationDto>>> GetArchivedApplications()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
                return BadRequest("User Not Found!");

            var userId = user.Id;
            var employee = _unitOfWork.Employees.Find(a => a.UserId == userId).FirstOrDefault();
            if (employee == null)
                return BadRequest("Employee Not Found!");

            var employeeApplications = _unitOfWork.Application.GetEmployeeArchivedApplications(employee.Id);
            return Ok(_mapper.Map<IEnumerable<ApplicationDto>>(employeeApplications));

        }

        /// Apply to job
        /// summary:
        /// this method takes job id as paramater
        /// Check if user didn't apply before or withdraw his previous application
        /// create new application
        /// set apply date to DateTime.Now()
        /// set IsArchived, IsViewed, and IsWithdrawn to false
        /// TODO: update job application (++)
        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> PostApplication([FromBody] int id)
        {
            if ( !ModelState.IsValid)
                return BadRequest();

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
                return BadRequest("User not Found!");
            var userId = user.Id;
            var employee = _unitOfWork.Employees.Find(a => a.UserId == userId).FirstOrDefault();
            if (employee == null)
                return BadRequest("Employee not Found!");

            var application = _unitOfWork.Application.Find(a => a.JobId == id && a.EmployeeId == employee.Id).FirstOrDefault();
            var statusId = _unitOfWork.ApplicationStatus.Find(s => s.Name == Enums.ApplicationStatus.Applied.ToString()).First().Id;
            if (application == null || application.IsWithdrawn == true)
            {
                Application app = new()
                {
                    JobId = id,
                    ApplyDate = DateTime.Now,
                    IsArchived = false,
                    IsViewed = false,
                    IsWithdrawn = false,
                    EmployeeId = employee.Id,
                    ApplicationStatusId = statusId
                };
                _unitOfWork.Application.Add(app);

                // Update Job Total Applications
                var job = _unitOfWork.Jobs.Get(id);
                if (job == null)
                    return BadRequest("Error Occured!");
                job.TotalApplications++;
                _unitOfWork.Jobs.Update(job);

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
        [HttpPut]
        [Authorize(Roles = "Employee")]
        //public IActionResult ArchiveApplication([FromBody] ArchiveApplicationDto archiveApplication)
        //{
        //    var application = _unitOfWork.Application.Find(a => a.Id == archiveApplication.Id).FirstOrDefault();
        //    if (application == null)
        //        return BadRequest("Cann't Find Application!");

        //    if (application.IsWithdrawn == true)
        //        return BadRequest("This application is withdrawn.");

        //    application.IsArchived = archiveApplication.Archived;
        //    application.ArchiveDate = archiveApplication.Archived ? DateTime.Now : null;
        //    _unitOfWork.Application.Update(application);
        //    _unitOfWork.SaveChanges();
        //    return Ok(application);
        //}

        // summary
        // this method takes application id as paramter 
        // it checks if application exists or if its already withdrawn then it return error
        // else it withdraw application
        // TODO: update job application count
        [HttpPut("withdraw")]
        [Authorize(Roles = "Employee")]
        public IActionResult WithdrawApplication([FromBody] int id)
        {
            var application = _unitOfWork.Application.Find(a => a.Id == id).FirstOrDefault();
            if (application == null)
                return BadRequest("Cann't Find Application!");

            if (application.IsWithdrawn == true)
                return BadRequest("This application is withdrawn.");

            var job = _unitOfWork.Jobs.Get(application.JobId);
            if (job == null)
                return BadRequest("Error Occured!");

            application.IsWithdrawn = true;
            application.WithDrawDate = DateTime.Now;

            // get all statuses
            var applicationStatuses = _unitOfWork.ApplicationStatus.GetAll().ToList();

            // decrement old status
            if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Viewed.ToString()).First().Id)
            {
                job.ViewedApplications--;
            }
            else if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.InConsidration.ToString()).First().Id)
            {
                job.InConsidrationApplications--;
            }
            else if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Rejected.ToString()).First().Id)
            {
                job.RejectedApplications--;
            }
            else if (application.ApplicationStatusId == applicationStatuses.Where(s => s.Name == Enums.ApplicationStatus.Hired.ToString()).First().Id)
            {
                job.AcceptedApplications--;
            }
            
            // decrement total applications
            job.TotalApplications--;
            // increment withdrawn applications
            job.WithdrawnApplications++;

            _unitOfWork.Jobs.Update(job);
            _unitOfWork.Application.Update(application);
            
            _unitOfWork.SaveChanges();
            
            return Ok(application);
        }
    }
}
