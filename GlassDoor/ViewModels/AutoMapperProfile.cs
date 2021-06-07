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

        }
    }
}
