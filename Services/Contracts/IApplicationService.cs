using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Models.Entities;
using JobMap.API.Utilities.OperationResults;

namespace JobMap.API.Services.Contracts
{
    public interface IApplicationService
    {
        Task<IEnumerable<JobApplicationResponse>> GetJobApplicationsAsync();
        Task<JobApplicationResponse?> GetJobApplicationByIdAsync(Guid id);
        Task<OperationResult> CreateJobApplicationAsync(CreateJobApplicationCommand jobApplication);
        Task<OperationResult> RemoveJobApplicationAsync(Guid id);
    }
}
