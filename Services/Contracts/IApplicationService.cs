using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Models.Entities;
using JobMap.API.Utilities.OperationResults;

namespace JobMap.API.Services.Contracts
{
    public interface IApplicationService
    {
        Task<OperationResult<IEnumerable<JobApplicationResponse>>> GetJobApplicationsAsync();
        Task<OperationResult<JobApplicationResponse>> GetJobApplicationByIdAsync(Guid id);
        Task<OperationResult<JobApplicationResponse>> CreateJobApplicationAsync(CreateJobApplicationRequest jobApplication);
        Task<JobApplicationResponse?> UpdateJobApplicationAsync(Guid id, UpdateJobApplicationRequest jobApplication);
        Task<OperationResult> RemoveJobApplicationAsync(Guid id);
    }
}
