﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class CompanyJobDetailsDto
    {
        public int Id { get; set; }
        public int? ExperienceNeededMin { get; set; }
        public int? ExperienceNeededMax { get; set; }
        public int CareerLevelId { get; set; }
        public CareerLevelDto CareerLevel { get; set; }
        public int EducationLevelId { get; set; }
        public EducationLevelDto EducationLevel { get; set; }
        public int? SalaryMin { get; set; }
        public int? SalaryMax { get; set; }
        public int SalaryCurrencyId { get; set; }
        public CurrencyDto SalaryCurrency { get; set; }
        public int SalaryRateId { get; set; }
        public SalaryRateDto SalaryRate { get; set; }

        public int JobCategoryId { get; set; }
        public JobCategoryDto JobCategory { get; set; }

        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Responsibilities { get; set; }

    }
}
