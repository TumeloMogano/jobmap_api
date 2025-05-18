using AutoMapper;
using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Models.Entities;

namespace JobMap.API.Utilities.Mappings
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile()
        {
            CreateMap<JobApplication, JobApplicationResponse>();
        }
    }
}
