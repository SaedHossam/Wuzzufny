using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class ApplicationDto
    {
        public int JobId { get; set; }
        public int Id { get; set; }
        public string CompanyLogo { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime ApplyDate { get; set; }
        public DateTime PostDate { get; set; }
        public string Industry { get; set; }
        public string JobType { get; set; }
        public int Vacancies { get; set; }
        public JobStatisticsViewModel JobStatistics { get; set; }

    }
    public class ArchiveApplicationDto
    {
        public int Id { get; set; }
        public bool Archived { get; set; }
    }
}
