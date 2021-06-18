using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using GlassDoor.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace GlassDoor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("insights")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<AdminInsightsDto>> GetInsights()
        {
            // ToDo: use better query than this
            var dateList = Enumerable.Range(0, 7)
                .Select(offset => DateTime.Today.AddDays(-1 * offset))
                .ToArray();

            List<JobsByDate> jobs = new List<JobsByDate>();
            foreach (var date in dateList)
            {
                jobs.Add(new JobsByDate()
                {
                    Date = date.ToString("yyyy-MM-dd"),
                    Count = _context.Jobs.Count(j => j.CreatedDate.Date == date.Date)

                });
            }

            var data = new AdminInsightsDto()
            {
                CompaniesCount = _context.Companies.Count(),

                OpenJobsByCountry = _context.Countries.Select(c => new JobsByCountry()
                {
                    Country = c.Name,
                    Count = c.Jobs.Count(j => j.IsOpen)
                })
                    .ToList(),

                OpenJobsByType = _context.JobTypes.Select(j => new JobsByType()
                {
                    Type = j.Name,
                    Count = j.Jobs.Count(job => job.IsOpen)
                })
                    .ToList(),

                OpenJobsByJobCategory = _context.JobCategories.Select(c => new JobsByJobCategory()
                {
                    Category = c.Name,
                    Count = c.JobDetails.Count(j => j.Job.IsOpen)
                })
                    .ToList(),

                OpenJobs = _context.Jobs.Count(j => j.IsOpen),

                //TotalJobsByDate = _context.Jobs.Where(j => j.CreatedDate > date)
                //    .OrderByDescending(j => j.CreatedDate)
                //    .GroupBy(j => j.CreatedDate)
                //    .Select(g => new JobsByDate() {Date = g.Key.ToString("yyyy-MM-dd"), Count = g.Count()})
                //    .ToList()
                //

                TotalJobsByDate = jobs

            };
            return Ok(data);
        }
    }
}
