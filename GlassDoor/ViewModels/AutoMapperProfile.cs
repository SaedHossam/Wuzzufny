using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using glassDoor.ViewModels;

namespace GlassDoor.ViewModels
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserForRegistrationDto, ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
            CreateMap<CompanySize, CompanySizeDto>().ReverseMap();
            CreateMap<CompanySizeCreateDto, CompanySize>();
            CreateMap<CompanyIndustry, CompanyIndustryDto>().ReverseMap();
            CreateMap<CompanyIndustryCreateDto, CompanyIndustry>();
            CreateMap<CompanyForRegistrationDto, Company>();
            CreateMap<CompanyForRegistrationDto, ApplicationUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));

            CreateMap<CareerLevelDto, CareerLevel>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
            CreateMap<CompanyTypeDto, CompanyType>().ReverseMap();
            CreateMap<CountryDto, Country>()
                .ForMember(c => c.Cities, opt => opt.MapFrom(s => s.Cities))
                .ReverseMap();
            CreateMap<CurrencyDto, Currency>().ReverseMap();
            CreateMap<EducationLevelDto, EducationLevel>().ReverseMap();
            CreateMap<JobCategoryDto, JobCategory>().ReverseMap();
            CreateMap<LanguageDto, Language>().ReverseMap();
            CreateMap<SkillsDto, Skill>().ReverseMap();
            CreateMap<SalaryRateDto, SalaryRate>().ReverseMap();


            // All Jobs View mapping
            CreateMap<Job, JobViewModel>()
                .ForMember(a => a.JobCityName, map => map.MapFrom(s => s.City.Name))
                .ForMember(a => a.JobCountryName, map => map.MapFrom(s => s.Country.Name))
                .ForMember(a => a.CompanyName, map => map.MapFrom(s => s.Company.Name))
                .ForMember(a => a.JobTypeName, map => map.MapFrom(s => s.JobType.Name))
                .ReverseMap();

            CreateMap<Skill, SkillsDto>()
                .ReverseMap();

            CreateMap<JobSkill, SkillsDto>()
                .ForMember(d => d.Id, map => map.MapFrom(s => s.SkillsId))
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Skills.Name))
                .ReverseMap();

            // job details mapping
            CreateMap<JobDetails, JobDetailsDto>()
                .ForMember(d => d.CareerLevelName, map => map.MapFrom(s => s.CareerLevel.Name))
                .ForMember(d => d.EducationLevelName, map => map.MapFrom(s => s.EducationLevel.Name))
                .ForMember(d => d.SalaryCurrencyName, map => map.MapFrom(s => s.SalaryCurrency.Name))
                .ForMember(d => d.SalaryRate, map => map.MapFrom(s => s.SalaryRate.Name))
                .ForMember(d => d.Category, map => map.MapFrom(s => s.JobCategory.Name))
                .ForMember(d => d.JobCountry, map => map.MapFrom(s => s.Job.Country.Name))
                .ForMember(d => d.JobCity, map => map.MapFrom(s => s.Job.City.Name))
                .ForMember(d => d.JobTitle, map => map.MapFrom(s => s.Job.Title))
                .ForMember(d => d.CompanyName, map => map.MapFrom(s => s.Job.Company.Name))
                .ForMember(d => d.JobType, map => map.MapFrom(s => s.Job.JobType.Name))
                .ForMember(d => d.CreatedDate, map => map.MapFrom(s => s.Job.CreatedDate))
                .ForMember(d => d.SalaryCurrencyCode, map => map.MapFrom(s => s.SalaryCurrency.Code))
                .ForMember(d => d.SkillsNames, map => map.MapFrom(s => s.Job.Skills))
                .ReverseMap();
            CreateMap<PostJobDto, Job>();

            CreateMap<Job, Job>();


            //Employee mapping
            CreateMap<JobType, JobTypeDto>()
             .ReverseMap();

            CreateMap<UserLanguage, UserLanguageDto>()
                  .ForMember(d => d.Level, map => map.MapFrom(s => s.Level))
                .ReverseMap();

            CreateMap<EmployeeLinks, EmployeeLinksDto>()
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.Link, map => map.MapFrom(s => s.Link))
                .ReverseMap();

            CreateMap<JobCategory, JobCategoryDto>()
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
                .ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                .ReverseMap();

            CreateMap<Employee, EmployeeDto>()
                .ForMember(d => d.CityName, map => map.MapFrom(s => s.City.Name))
                .ForMember(d => d.CountryName, map => map.MapFrom(s => s.Country.Name))
                .ForMember(d => d.CareerLevelName, map => map.MapFrom(s => s.CareerLevel.Name))
                .ForMember(d => d.CareerLevelName, map => map.MapFrom(s => s.CareerLevel.Name))
                .ForMember(d => d.EducationLevelName, map => map.MapFrom(s => s.EducationLevel.Name))
                .ForMember(d => d.NationalityName, map => map.MapFrom(s => s.Nationality.Name))
                .ForMember(d => d.UserFirstName, map => map.MapFrom(s => s.User.FirstName))
                .ForMember(d => d.UserLastName, map => map.MapFrom(s => s.User.LastName))
                .ForMember(d => d.JobTypesName, map => map.MapFrom(s => s.JobTypes))
                .ForMember(d => d.SkillsNames, map => map.MapFrom(s => s.Skills))
                .ForMember(d => d.UserLanguagesNames, map => map.MapFrom(s => s.UserLanguages))
                .ForMember(d => d.EmployeeLinksNames, map => map.MapFrom(s => s.EmployeeLinks))
                .ForMember(d => d.PreferredJobCategoriesName, map => map.MapFrom(s => s.PreferredJobCategories))
                .ForMember(d => d.Email, map => map.MapFrom(s => s.User.Email))

                .ReverseMap();

            CreateMap<UserLanguage, UserLanguageDto>()
                .ForMember(d => d.Name, map => map.MapFrom(s => s.Language.Name))
                .ReverseMap();

            // application user
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(d => d.FirstName, map => map.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, map => map.MapFrom(s => s.LastName))
                //.ForMember(d =>d.Email, map => map.MapFrom(s => s.Email))
                .ReverseMap();

            //Update Employee Profile
            CreateMap<Employee, UpdateEmployeeDto>()
                .ForMember(d => d.AlternativeMobileNumber, map => map.MapFrom(s => s.AlternativeMobileNumber))
                .ForMember(d => d.CareerLevelId, map => map.MapFrom(s => s.CareerLevel.Id))
                .ForMember(d => d.CityId, map => map.MapFrom(s => s.City.Id))
                .ForMember(d => d.CountryId, map => map.MapFrom(s => s.Country.Id))
                .ForMember(d => d.CV, map => map.MapFrom(s => s.CV))
                .ForMember(d => d.EducationLevelId, map => map.MapFrom(s => s.EducationLevel.Id))
                .ForMember(d => d.ExperienceYears, map => map.MapFrom(s => s.ExperienceYears))
                //.ForMember(d => d.Id, map => map.MapFrom(s => s.Id))
                .ForMember(d => d.IsWillingToRelocate, map => map.MapFrom(s => s.IsWillingToRelocate))
                .ForMember(d => d.MilitaryStatus, map => map.MapFrom(s => s.MilitaryStatus))
                .ForMember(d => d.MobileNumber, map => map.MapFrom(s => s.MobileNumber))
                .ForMember(d => d.Photo, map => map.MapFrom(s => s.Photo))
                //.ForMember(d => d.PreferredJobCategories, map => map.MapFrom(s => s.))
                .ForMember(d => d.Summary, map => map.MapFrom(s => s.Summary))
                .ReverseMap();

            // update job category

            CreateMap<JobCategory, PreferedJobCatDto>()
               .ForMember(d => d.PreferredJobCategories, map => map.MapFrom(s => s.Id))
               .ReverseMap();

            //// mapping the name of employee link name 
            //CreateMap<EmployeeLinks, EmployeeLinksManager>()
            //   .ForMember(d => d.Name, map => map.MapFrom(s => s.Name))
            //   .ReverseMap();


        }
    }
}
