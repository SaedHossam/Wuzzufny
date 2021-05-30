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

            CreateMap<Job, JobViewModel>()
                .ReverseMap();
            CreateMap<JobDetails, JobDetailsViewModel>()
                .ReverseMap();
            CreateMap<Skill, SkillsViewModel>()
                .ReverseMap();
        }
    }
}
