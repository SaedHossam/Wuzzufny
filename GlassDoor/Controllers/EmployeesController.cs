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
using Microsoft.AspNetCore.Identity;
using GlassDoor.ViewModels;
using Microsoft.AspNetCore.Authorization;
using GlassDoor.Constants;
using System.IO;
using System.Net.Http.Headers;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _DB;
        public EmployeesController(IMapper mapper, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, ApplicationDbContext DB)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _DB = DB;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var empData = _unitOfWork.Employees.GetEmployeeData();
            if (empData == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(empData));
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = _unitOfWork.Employees.GetEmployeeDataById(id);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDto>(employee));

        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Employee")]
        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> PutEmployee(UpdateEmployeeDto updatedEmp)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetEmpData(emp.Id);
            employee.AlternativeMobileNumber = updatedEmp.AlternativeMobileNumber;
            employee.BirthDate = updatedEmp.BirthDate;
            employee.CountryId = updatedEmp.CountryId;
            employee.User.FirstName = updatedEmp.UserFirstName;
            employee.User.LastName = updatedEmp.UserLastName;
            //employee.EducationLevelId = updatedEmp.EducationLevelId;
            //employee.ExperienceYears = updatedEmp.ExperienceYears;
            employee.Gender = updatedEmp.Gender;
            employee.IsWillingToRelocate = updatedEmp.IsWillingToRelocate;
            employee.CityId = updatedEmp.CityId;
            employee.MobileNumber = updatedEmp.MobileNumber;
            employee.NationalityId = updatedEmp.NationalityId;
            _unitOfWork.SaveChanges();
            return NoContent();

        }
        [Authorize(Roles = "Employee")]
        [HttpPut("User")]
        public async Task<IActionResult> PutEmployee(ApplicationUserDto appUser)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            //user.Email = appUser.Email;

            //TODO : function to confirm new email first then update it.
            await _userManager.UpdateAsync(user);

            return NoContent();

        }


        [Authorize(Roles = "Employee")]
        [HttpPut("EducationAndExperience")]
        public async Task<IActionResult> PutEmployee(EducationAndExpDto edu_exp)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetEmpData(emp.Id);
            if (edu_exp.EducationLevelId != 0)
            {
                employee.EducationLevelId = edu_exp.EducationLevelId;
            }
            if (edu_exp.ExperienceYears != 0)
            {
                employee.ExperienceYears = edu_exp.ExperienceYears;
            }
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpPut("jobCategory")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> PutEmployee(CarrerInterestDto EmployeeJobCategory)
        {
            // THIS API update all in career interset in the UI
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetJobCateogyForOneEmp(emp.Id);
            var theSameEmployee = _unitOfWork.Employees.GetEmpJobTypes(emp.Id);

            if (EmployeeJobCategory.CareerLevelId != null)
            {
                employee.CareerLevelId = EmployeeJobCategory.CareerLevelId;
            }

            if (EmployeeJobCategory.MinimumSalary != 0)
            {
                employee.MinimumSalary = EmployeeJobCategory.MinimumSalary;
            }

            if (EmployeeJobCategory.PreferredJobCategories != null)
            {
                List<int> addedCat = new List<int>();
                List<int> removeCat = new List<int>();
                List<int> empCat = employee.PreferredJobCategories.Select(e => e.Id).ToList();

                addedCat = EmployeeJobCategory.PreferredJobCategories.Except(empCat).ToList();

                removeCat = empCat.Except(EmployeeJobCategory.PreferredJobCategories).ToList();

                foreach (var removeCategory in removeCat)
                {
                    var categotyToRemove = _unitOfWork.JobCategory.Get(removeCategory);
                    employee.PreferredJobCategories.Remove(categotyToRemove);

                }

                foreach (var addedCategory in addedCat)
                {
                    var categotyToAdd = _unitOfWork.JobCategory.Get(addedCategory);
                    employee.PreferredJobCategories.Add(categotyToAdd);
                }
            }
            if (EmployeeJobCategory.JobTypeId != null)
            {
                List<int> addJobType = new List<int>();
                List<int> removeJobType = new List<int>();
                List<int> empJobType = theSameEmployee.JobTypes.Select(e => e.Id).ToList();

                addJobType = EmployeeJobCategory.JobTypeId.Except(empJobType).ToList();

                removeJobType = empJobType.Except(EmployeeJobCategory.JobTypeId).ToList();

                foreach (var removeJobTypes in removeJobType)
                {
                    var JobTypeToRemove = _unitOfWork.JobType.Get(removeJobTypes);
                    theSameEmployee.JobTypes.Remove(JobTypeToRemove);

                }

                foreach (var addedJobType in addJobType)
                {
                    var JobTypeToAdd = _unitOfWork.JobType.Get(addedJobType);
                    theSameEmployee.JobTypes.Add(JobTypeToAdd);
                }
            }
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpPut("SkillAndLanguage")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> PutEmployee(SkillAndLanguageDto EmployeeSkills)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetEmpSkills(emp.Id);
            var theSameEmployee = _unitOfWork.Employees.GetEmpLanguages(emp.Id);

            if (EmployeeSkills.SkillId != null)
            {
                List<int> addSkill = new List<int>();
                List<int> removeSkill = new List<int>();
                List<int> empSkill = employee.Skills.Select(e => e.Id).ToList();

                addSkill = EmployeeSkills.SkillId.Except(empSkill).ToList();

                removeSkill = empSkill.Except(EmployeeSkills.SkillId).ToList();

                foreach (var removeSkills in removeSkill)
                {
                    var skillToRemove = _unitOfWork.Skills.Get(removeSkills);
                    employee.Skills.Remove(skillToRemove);

                }

                foreach (var addedskill in addSkill)
                {
                    var skillToAdd = _unitOfWork.Skills.Get(addedskill);
                    employee.Skills.Add(skillToAdd);
                }

            }
            if (EmployeeSkills.LanguageId != null)
            {
                List<int> addLanguage = new List<int>();
                List<int> removeLanguage = new List<int>();
                List<int> empLanguage = theSameEmployee.UserLanguages.Select(e => e.Id).ToList();

                addLanguage = EmployeeSkills.LanguageId.Except(empLanguage).ToList();

                removeLanguage = empLanguage.Except(EmployeeSkills.LanguageId).ToList();

                foreach (var removeLanguages in removeLanguage)
                {
                    var LanguageToRemove = _unitOfWork.UserLanguage.Get(removeLanguages);
                    theSameEmployee.UserLanguages.Remove(LanguageToRemove);

                }

                foreach (var addedLanguage in addLanguage)
                {
                    var userLanguage = new UserLanguage
                    {
                        EmployeeId = employee.Id,
                        LanguageId = addedLanguage,
                        Level = EmployeeSkills.Level

                    };
                    theSameEmployee.UserLanguages.Add(userLanguage);
                }

            }
            _unitOfWork.SaveChanges();
            return NoContent();
        }


        // NO NEED

        // NO NEED
        //[HttpPut("JobTypes")]
        //[Authorize(Roles = "Employee")]
        //public async Task<IActionResult> PutEmployee(JobTypesManager EmployeeJobTypes)
        //{
        //    var user = await _userManager.GetUserAsync(HttpContext.User);
        //    var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
        //    var employee = _unitOfWork.Employees.GetEmpJobTypes(emp.Id);

        //    //List<int> addJobType = new List<int>();
        //    //List<int> removeJobType = new List<int>();
        //    //List<int> empJobType = employee.JobTypes.Select(e => e.Id).ToList();

        //    //addJobType = EmployeeJobTypes.JobTypeId.Except(empJobType).ToList();

        //    //removeJobType = empJobType.Except(EmployeeJobTypes.JobTypeId).ToList();

        //    //foreach (var removeJobTypes in removeJobType)
        //    //{
        //    //    var JobTypeToRemove = _unitOfWork.JobType.Get(removeJobTypes);
        //    //    employee.JobTypes.Remove(JobTypeToRemove);

        //    //}

        //    //foreach (var addedJobType in addJobType)
        //    //{
        //    //    var JobTypeToAdd = _unitOfWork.JobType.Get(addedJobType);
        //    //    employee.JobTypes.Add(JobTypeToAdd);
        //    //}

        //    _unitOfWork.SaveChanges();
        //    return NoContent();
        //}

        //[HttpPut("Languages")]
        //[Authorize(Roles = "Employee")]
        //public async Task<IActionResult> PutEmployee(LanguageManager EmployeeLanguages)
        //{
        //    var user = await _userManager.GetUserAsync(HttpContext.User);
        //    var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
        //    var employee = _unitOfWork.Employees.GetEmpLanguages(emp.Id);

        //    List<int> addLanguage = new List<int>();
        //    List<int> removeLanguage = new List<int>();
        //    List<int> empLanguage = employee.UserLanguages.Select(e => e.Id).ToList();

        //    addLanguage = EmployeeLanguages.LanguageId.Except(empLanguage).ToList();

        //    removeLanguage = empLanguage.Except(EmployeeLanguages.LanguageId).ToList();

        //    foreach (var removeLanguages in removeLanguage)
        //    {
        //        var LanguageToRemove = _unitOfWork.UserLanguage.Get(removeLanguages);
        //        employee.UserLanguages.Remove(LanguageToRemove);

        //    }

        //    foreach (var addedLanguage in addLanguage)
        //    {
        //        var userLanguage = new UserLanguage
        //        {
        //            EmployeeId = employee.Id,
        //            LanguageId = addedLanguage,
        //            Level = EmployeeLanguages.Level

        //        };
        //        employee.UserLanguages.Add(userLanguage);
        //    }


        //    _unitOfWork.SaveChanges();
        //    return NoContent();
        //}


        [HttpPut("EmployeeLinks")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> PutEmployee(ICollection<EmployeeLinksManager> EmployeeLinks)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetEmpLinks(emp.Id);

            foreach (var item in EmployeeLinks)
            {
                var empLink = employee.EmployeeLinks.FirstOrDefault(e => e.Name == item.FacebookName);
                if (empLink == null)
                {
                    employee.EmployeeLinks.Add(new EmployeeLinks() { Name = item.FacebookName, Link = item.FacebookLink });
                }
                else
                {
                    empLink.Link = item.FacebookLink;
                }
                
                var empLink2 = employee.EmployeeLinks.FirstOrDefault(e => e.Name == item.LinkedInName);
                if (empLink2 == null)
                {
                    employee.EmployeeLinks.Add(new EmployeeLinks() { Name = item.LinkedInName, Link = item.LinkedInLink });
                }
                else
                {
                    empLink2.Link = item.LinkedInLink;
                }
                
                var empLink3 = employee.EmployeeLinks.FirstOrDefault(e => e.Name == item.TwitterName);
                if (empLink3 == null)
                {
                    employee.EmployeeLinks.Add(new EmployeeLinks() { Name = item.TwitterName, Link = item.TwitterLink });
                }
                else
                {
                    empLink3.Link = item.TwitterLink;
                } 
                
                var empLink4 = employee.EmployeeLinks.FirstOrDefault(e => e.Name == item.GithubName);
                if (empLink4 == null)
                {
                    employee.EmployeeLinks.Add(new EmployeeLinks() { Name = item.GithubName, Link = item.GithubLink });
                }
                else
                {
                    empLink4.Link = item.GithubLink;
                }

            }
            _unitOfWork.SaveChanges();
            return NoContent();
        }

        [HttpPost("Upload"), DisableRequestSizeLimit]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetEmpData(emp.Id);

            var fileName = employee.UserId + ".png";

            try
            {
                var formCollection = await Request.ReadFormAsync();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    employee.Photo = dbPath;
                    _unitOfWork.SaveChanges();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPost("UploadCv"), DisableRequestSizeLimit]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UploadCv(IFormFile Cv)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var emp = _unitOfWork.Employees.Find(e => e.UserId == user.Id).FirstOrDefault();
            var employee = _unitOfWork.Employees.GetEmpData(emp.Id);
            var path = Path.GetFullPath(Cv.FileName);
            //Guid.NewGuid();
            var fileName = employee.UserId;
            if (employee.CV != null)
            {
                var pathToDelete = Path.Combine(Directory.GetCurrentDirectory(), employee.CV);
                System.IO.File.Delete(pathToDelete);
            }
            if (Path.GetExtension(path).Contains(".pdf"))
            {
                fileName += ".pdf";
            }
            else if (Path.GetExtension(path).Contains(".docx"))
            {
                fileName += ".docx";
            }


            try
            {
                var formCollection = await Request.ReadFormAsync();
                var folderName = Path.Combine("Resources", "Cv");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (Cv.Length > 0)
                {

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        Cv.CopyTo(stream);

                    }
                    employee.CV = dbPath;
                    _unitOfWork.SaveChanges();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _DB.Employees.Add(employee);
            await _DB.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _DB.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _DB.Employees.Remove(employee);
            await _DB.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _DB.Employees.Any(e => e.Id == id);
        }
    }
}
