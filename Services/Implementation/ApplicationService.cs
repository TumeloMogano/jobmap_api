using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Models.Entities;
using JobMap.API.Repositories.Contracts;
using JobMap.API.Services.Contracts;
using JobMap.API.Utilities.OperationResults;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Net.Mime.MediaTypeNames;

namespace JobMap.API.Services.Implementation
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _repository;
        public ApplicationService(IApplicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JobApplicationResponse>> GetJobApplicationsAsync()
        {
            var jobApplications = await _repository.GetJobApplicationsAsync();

            //Map domain model received from repo to dto
            var response = new List<JobApplicationResponse>();

            foreach (var application in jobApplications)
            {
                response.Add(new JobApplicationResponse
                {
                    Id = application.Id,
                    CompanyName = application.CompanyName,
                    RoleTitle = application.RoleTitle,
                    Location = application.Location,
                    StatusId = application.StatusId,
                    MainContactEmail = application.MainContactEmail,
                    MainContactName = application.MainContactName,
                    MainContactPhone = application.MainContactPhone,
                    HiringLikelihoodId = application.HiringLikelihoodId,
                    OpeningDate = application.OpeningDate,
                    DateApplied = application.DateApplied,
                    ClosingDate = application.ClosingDate,
                    SalaryExpectationRange = application.SalaryExpectationRange,
                    RequiredDocumentation = application.RequiredDocumentation,
                    IsClosed = application.IsClosed,
                    Notes = application.Notes,
                    CreatedAt = application.CreatedAt,
                    UpdatedAt = application.UpdatedAt
                });
            }

            return response;
        }
        public async Task<JobApplicationResponse?> GetJobApplicationByIdAsync(Guid id)
        {
            var jobApplication = await _repository.GetJobApplicationByIdAsync(id);

            if (jobApplication == null)
                return null;

            var response = new JobApplicationResponse
            {
                Id = jobApplication.Id,
                CompanyName = jobApplication.CompanyName,
                RoleTitle = jobApplication.RoleTitle,
                Location = jobApplication.Location,
                StatusId = jobApplication.StatusId,
                MainContactEmail = jobApplication.MainContactEmail,
                MainContactName = jobApplication.MainContactName,
                MainContactPhone = jobApplication.MainContactPhone,
                HiringLikelihoodId = jobApplication.HiringLikelihoodId,
                OpeningDate = jobApplication.OpeningDate,
                DateApplied = jobApplication.DateApplied,
                ClosingDate = jobApplication.ClosingDate,
                SalaryExpectationRange = jobApplication.SalaryExpectationRange,
                RequiredDocumentation = jobApplication.RequiredDocumentation,
                IsClosed = jobApplication.IsClosed,
                Notes = jobApplication.Notes,
                CreatedAt = jobApplication.CreatedAt,
                UpdatedAt = jobApplication.UpdatedAt
            };

            return response;
        }

        public async Task<OperationResult> CreateJobApplicationAsync(CreateJobApplicationCommand jobApplication)
        {
            //Manually Map Data from DTO to new JobApplication instance
            var query = new JobApplication
            {
                CompanyName = jobApplication.CompanyName,
                RoleTitle = jobApplication.RoleTitle,
                Location = jobApplication.Location,
                StatusId = jobApplication.StatusId,
                MainContactEmail = jobApplication.MainContactEmail,
                MainContactName = jobApplication.MainContactName,
                MainContactPhone = jobApplication.MainContactPhone,
                HiringLikelihoodId = jobApplication.HiringLikelihoodId,
                OpeningDate = jobApplication.OpeningDate,
                DateApplied = jobApplication.DateApplied,
                ClosingDate = jobApplication.ClosingDate,
                SalaryExpectationRange = jobApplication.SalaryExpectationRange,
                RequiredDocumentation = jobApplication.RequiredDocumentation,
                IsClosed = jobApplication.IsClosed,
                Notes = jobApplication.Notes,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _repository.CreateJobApplicationAsync(query);

            var response = new OperationResult
            {
                isSuccess = true,
                Message = "Job Application Created Successfully!"
            };

            return response;
        }

        public async Task<JobApplicationResponse?> UpdateJobApplicationAsync(Guid id, UpdateJobApplicationCommand jobApplication)
        {
            var newApplication = new JobApplication
            {
                Id = id,
                CompanyName = jobApplication.CompanyName,
                RoleTitle = jobApplication.RoleTitle,
                Location = jobApplication.Location,
                StatusId = jobApplication.StatusId,
                MainContactName = jobApplication.MainContactName,
                MainContactEmail = jobApplication.MainContactEmail,
                MainContactPhone = jobApplication.MainContactPhone,
                HiringLikelihoodId = jobApplication.HiringLikelihoodId,
                OpeningDate = jobApplication.OpeningDate,
                DateApplied = jobApplication.DateApplied,
                ClosingDate = jobApplication.ClosingDate,
                SalaryExpectationRange = jobApplication.SalaryExpectationRange,
                RequiredDocumentation = jobApplication.RequiredDocumentation,
                IsClosed = jobApplication.IsClosed,
                Notes = jobApplication.Notes,
                UpdatedAt = DateTime.Now
            };

            var updatedApplication = await _repository.UpdateJobApplicationAsync(newApplication);

            if (updatedApplication is null)
                return null;

            var response = new JobApplicationResponse
            {
                Id = updatedApplication.Id,                
                CompanyName = updatedApplication.CompanyName,
                RoleTitle = updatedApplication.RoleTitle,
                Location = updatedApplication.Location,
                StatusId = updatedApplication.StatusId,
                MainContactEmail = updatedApplication.MainContactEmail,
                MainContactName = updatedApplication.MainContactName,
                MainContactPhone = updatedApplication.MainContactPhone,
                HiringLikelihoodId = updatedApplication.HiringLikelihoodId,
                OpeningDate = updatedApplication.OpeningDate,
                DateApplied = updatedApplication.DateApplied,
                ClosingDate = updatedApplication.ClosingDate,
                SalaryExpectationRange = updatedApplication.SalaryExpectationRange,
                RequiredDocumentation = updatedApplication.RequiredDocumentation,
                IsClosed = updatedApplication.IsClosed,
                Notes = updatedApplication.Notes,
                CreatedAt = updatedApplication.CreatedAt,
                UpdatedAt = updatedApplication.UpdatedAt
            };

            return response;

        }

        public async Task<OperationResult> RemoveJobApplicationAsync(Guid id)
        {
            var command = await _repository.RemoveJobApplicationAsync(id);

            if (command == false)
            {
                return new OperationResult
                {
                    isSuccess = false,
                    Message = "Job Application with id - {" + id.ToString() + "} could not be deleted."
                };
            }

            var response = new OperationResult
            {
                isSuccess = true,
                Message = "Job Application with id - {" + id.ToString() +"} deleted."
            };

            return response;
        }

    }
}
