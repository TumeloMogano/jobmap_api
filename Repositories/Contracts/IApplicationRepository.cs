using JobMap.API.Models.Entities;

namespace JobMap.API.Repositories.Contracts
{
    public interface IApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetJobApplicationsAsync();
        Task<JobApplication?> GetJobApplicationByIdAsync(Guid id);
        Task<JobApplication?> CreateJobApplicationAsync(JobApplication application);
        Task<JobApplication?> UpdateJobApplicationAsync(JobApplication application);
        Task<bool> RemoveJobApplicationAsync(Guid id);
    }
}
