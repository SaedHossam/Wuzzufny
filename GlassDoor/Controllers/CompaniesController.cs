using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using GlassDoor.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using GlassDoor.Constants;
using GlassDoor.services.email;
using System.IO;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private IEmailSender _emailSender;

        public CompaniesController(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork, IEmailSender emailSender, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return company;
        }
        //get company profile

        [HttpGet("CompanyProfile")]
        public async Task<ActionResult<CompanyProfileDto>> GetCompanyProfile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).First().Id;
            var company = _context.Companies
                .Include(a=>a.Locations)
                .ThenInclude(a=>a.cities).ThenInclude(c => c.Country)
                .Include(a=>a.CompanyLinks)
                .Include(a=> a.CompanyIndustry)
                .Include(a => a.CompanySize)
                .Include(a => a.CompanyType)
                .Include(a => a.Locations)
                .FirstOrDefault(a => a.Id == companyId);

            if (company == null)
            {
                return NotFound();
            }
            var companyDto = _mapper.Map<CompanyProfileDto>(company);
            companyDto.City = company.Locations.FirstOrDefault() != null ? company.Locations.FirstOrDefault()?.cities?.Name : "Not Entered";
            companyDto.Country = company.Locations.FirstOrDefault() != null ? company.Locations.FirstOrDefault()?.cities?.Country?.Name : "Not Entered";

            return companyDto;
        }
        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyProfile(int id, CompanyProfileDto company)
        {
            if (id != company.Id)
            {
                return BadRequest();
            }

            var oldCompany = _context.Companies
              .Include(a => a.Locations)
              .Include(a => a.CompanyLinks)
              .Include(a => a.CompanyIndustry)
              .Include(a => a.CompanySize)
              .Include(a => a.CompanyType)
              
              .FirstOrDefault(a => a.Id == company.Id);
       
            var newCompany = _mapper.Map<Company>(company);
            _mapper.Map<Company, Company>(newCompany, oldCompany);
            var industry = _context.CompanyIndustries.FirstOrDefault(a => a.Id == company.CompanyIndustryId);
            oldCompany.CompanyIndustry = industry;
            var size = _context.CompanySizes.FirstOrDefault(a => a.Id == company.CompanySizeId);
            oldCompany.CompanySize = size;
            var type = _context.CompanyTypes.FirstOrDefault(a => a.Id == company.CompanyTypeId);
            oldCompany.CompanyType = type;
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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
        //upload Logo
        [HttpPost("Upload"), DisableRequestSizeLimit]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var companyId = _unitOfWork.CompaniesManagers.Find(c => c.UserId == user.Id).FirstOrDefault().Id;
            var company = _unitOfWork.Companies.Find(a => a.Id == companyId).FirstOrDefault();
            var fileName = user.Id + ".png";

            try
            {
                var formCollection = await Request.ReadFormAsync();
                var folderName = Path.Combine("Resources", "company-logos");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                    company.Logo = dbPath;
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


        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[Authorize]
        // Get Requests for Creating Companies
        [Authorize(Roles = "Administrator")]
        [HttpGet("companiesRequests")]
        public ActionResult<IEnumerable<CompanyRequestsDto>> GetCompaniesRequests()
        {
            try
            {
                var statusId = _context.CompanyRequestStatus.FirstOrDefault(s => s.Name == Enums.CompanyRequestStatus.UnderReview.ToString()).Id;
                var companies =
                    _mapper.Map<IEnumerable<CompanyRequestsDto>>(
                        _context.Companies
                        .Include(s => s.CompanySize)
                        .Include(i => i.CompanyIndustry)
                        .Where(a => a.RequestStatusId == statusId));

                return Ok(companies);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        // Get Company Request by Id
        [Authorize(Roles = "Administrator")]
        [HttpGet("companiesRequests/{id}")]
        public ActionResult<CompanyRequestDto> GetCompanyRequest(int id)
        {
            Company company =
                _context.Companies
                .Include(s => s.CompanySize)
                .Include(i => i.CompanyIndustry)
                .Include(m => m.CompanyManagers)
                .ThenInclude(u => u.User)
                .Where(c => c.Id == id)
                .FirstOrDefault();

            var user = company.CompanyManagers.FirstOrDefault().User;
            CompanyRequestDto companyRequest = new CompanyRequestDto()
            {
                Id = company.Id,
                Name = company.Name,
                Industry = company.CompanyIndustry.Name,
                Size = company.CompanySize.Name,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Title = company.CompanyManagers.FirstOrDefault().Title,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            if (companyRequest == null)
            {
                return NotFound();
            }

            return Ok(companyRequest);
        }

        // post method that takes bool value that indicate weather request is confiremed or not
        [Authorize(Roles = "Administrator")]
        [HttpPost("requestStatus")]
        public async Task<ActionResult> PostRequestStatus([FromBody] CompanyRequestStatusDto requestStatus)
        {
            Company company =
                _context.Companies
                .Where(c => c.Id == requestStatus.Id)
                .Include(a => a.RequestStatus)
                .Include(c => c.CompanyManagers)
                .ThenInclude(cm => cm.User)
                .FirstOrDefault();

            if (company == null)
            {
                return BadRequest("Company doesn't exists");
            }

            if (company.RequestStatus.Name == Enums.CompanyRequestStatus.UnderReview.ToString())
            {
                int statusId;
                string messageText;
                if (requestStatus.Response)
                {
                    statusId = _context.CompanyRequestStatus
                        .First(a => a.Name == Enums.CompanyRequestStatus.Accepted.ToString()).Id;
                    messageText = "your company account is approved and you can start hiring";

                    var managerUserId = company.CompanyManagers.First().UserId;
                    var user = await _userManager.FindByIdAsync(managerUserId);
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                }
                else
                {
                    statusId = _context.CompanyRequestStatus
                        .First(a => a.Name == Enums.CompanyRequestStatus.Rejected.ToString()).Id;
                    messageText = "your company couldn't be approved, contact us for more details";
                }
                company.RequestStatusId = statusId;
                _context.SaveChanges();

                var email = company.CompanyManagers.First().User.Email;

                var message = new Message(new string[] { email }, "Company Account on JobFinder status update",
                    messageText, null, false);
                await _emailSender.SendEmailAsync(message);

                return Ok();
            }
            else
            {
                return StatusCode(500, "Can't change Company Status");
            }
        }
        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
