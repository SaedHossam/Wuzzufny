using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;

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

            CreateMap<PostJobDto, Job>();

            CreateMap<Job, Job>();

        }
    }
}
