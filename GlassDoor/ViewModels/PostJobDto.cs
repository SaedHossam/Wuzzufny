﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlassDoor.ViewModels
{
    public class PostJobDto
    {
        public int? Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int JobTypeId { get; set; }
        public int? NumberOfVacancies { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public bool? IsOpen { get; set; }
        public CompanyJobDetailsDto JobDetails { get; set; }
        public ICollection<CompanyJobSkillDto> Skills { get; set; }
    }
}

