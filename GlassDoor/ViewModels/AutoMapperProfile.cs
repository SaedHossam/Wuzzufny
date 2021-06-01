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
            CreateMap<PostJobDto, Job>();

            //CreateMap<PostJobDto, Job>()
            //    .BeforeMap((PostJobDto, Job) =>
            //    CreateMap<JobDetailsDto, JobDetails>())
            //.BeforeMap((JobDetailsDto, JobDetails) =>
            //CreateMap<SkillsDto, Skill>());


        }
    }
}
