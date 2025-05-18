using JobMap.API.Models.Entities;
using JobMap.API.Persistence.Data;
using JobMap.API.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JobMap.API.Repositories.Implementation
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly JobMapDbContext _context;

        public ApplicationRepository(JobMapDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationsAsync()
        {
            var JobApplications = await _context.JobApplications
                    .AsNoTracking()
                    .ToListAsync();

            return JobApplications;
        }
        public async Task<JobApplication?> GetJobApplicationByIdAsync(Guid id)
        {
            var jobApplication = await _context.JobApplications
                    .AsNoTracking()
                    .FirstOrDefaultAsync(j => j.Id == id);

            return jobApplication;
        }

        public async Task<JobApplication> CreateJobApplicationAsync(JobApplication application)
        {
            await _context.JobApplications.AddAsync(application);
            await _context.SaveChangesAsync();

            return application;
        }

        public async Task<JobApplication?> UpdateJobApplicationAsync(JobApplication application)
        {
            var existingApplication = await _context.JobApplications.FirstOrDefaultAsync(p => p.Id == application.Id);

            if (existingApplication != null)
            {
                _context.Entry(existingApplication).CurrentValues.SetValues(application);
                await _context.SaveChangesAsync();
                return existingApplication;
            }

            return null;
        }

        public async Task<bool> RemoveJobApplicationAsync(Guid id)
        {
            var jobApplication = await _context.JobApplications.FindAsync(id);

            return true;
        }

    }
}
