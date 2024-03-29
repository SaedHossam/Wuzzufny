﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using DAL.Models.Interfaces;

namespace DAL.Models
{
    public class Job: IAuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public int? NumberOfVacancies { get; set; }

        public int CityId { get; set; }
        public City City{ get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public int TotalApplications { get; set; }
        public int TotalClicks { get; set; }
        // Hired
        public int AcceptedApplications { get; set; }
        public int RejectedApplications { get; set; }
        public int ViewedApplications { get; set; }
        public int InConsiderationApplications { get; set; }
        public int WithdrawnApplications { get; set; }
        public bool IsOpen { get; set; }

        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public JobDetails JobDetails { get; set; }
        public ICollection<JobSkill> Skills { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
