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
                //.ForMember(u => u.Id, opt => opt.Ignore())
                //.ForMember(u => u.TotalApplications, opt => opt.Ignore())
                //.ForMember(u => u.TotalClicks, opt => opt.Ignore())
                //.ForMember(u => u.AcceptedApplications, opt => opt.Ignore())
                //.ForMember(u => u.RejectedApplications, opt => opt.Ignore())
                //.ForMember(u => u.ViewedApplications, opt => opt.Ignore())
                //.ForMember(u => u.WithdrawnApplications, opt => opt.Ignore())
                //.ForMember(u => u.UpdatedBy, opt => opt.Ignore())
                //.ForMember(u => u.UpdatedDate, opt => opt.Ignore());
                //.ForMember(u => u.Company, opt => opt.Ignore())
                //.ForMember(u => u.Applications, opt => opt.Ignore());

            //CreateMap<PostJobDto, Job>()
            //    .BeforeMap((PostJobDto, Job) =>
            //    CreateMap<JobDetailsDto, JobDetails>())
            //.BeforeMap((JobDetailsDto, JobDetails) =>
            //CreateMap<SkillsDto, Skill>());


        }
    }
}
