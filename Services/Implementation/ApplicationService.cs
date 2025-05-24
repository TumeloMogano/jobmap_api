using Azure.Core;
using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Models.Entities;
using JobMap.API.Repositories.Contracts;
using JobMap.API.Services.Contracts;
using JobMap.API.Utilities.OperationResults;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task<OperationResult<IEnumerable<JobApplicationResponse>>> GetJobApplicationsAsync()
        {

            try
            {
                var jobApplications = await _repository.GetJobApplicationsAsync();

                if (jobApplications == null || !jobApplications.Any())
                {
                    return OperationResult<IEnumerable<JobApplicationResponse>>.Success(
                        new List<JobApplicationResponse>(), "No Job Applications found.");
                }

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

                return OperationResult<IEnumerable<JobApplicationResponse>>.Success(response, "Successfully retrieved job applications.");
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<JobApplicationResponse>>.Fail($"An Error occured while retrieving job applications: {ex.Message}");
            }
                        
        }
        public async Task<OperationResult<JobApplicationResponse>> GetJobApplicationByIdAsync(Guid id)
        {
            try
            {
                var jobApplication = await _repository.GetJobApplicationByIdAsync(id);

                if (jobApplication == null)
                    return OperationResult<JobApplicationResponse>.Fail("Job application not found.", null);

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

                return OperationResult<JobApplicationResponse>.Success(response, "Successfully retrieved job application.");
            }
            catch (Exception ex)
            {
                return OperationResult<JobApplicationResponse>.Fail($"An error occurred: {ex.Message}");
            }
        }

        public async Task<OperationResult<JobApplicationResponse>> CreateJobApplicationAsync(CreateJobApplicationRequest jobApplication)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(jobApplication.CompanyName))
                    return OperationResult<JobApplicationResponse>.Fail("Company name is required.", null);

                /* manually map data from dto to new JobApplication instance.*/
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

                var resultObject = await _repository.CreateJobApplicationAsync(query);

                /* return a failure result when the repository does not return an object.*/
                if (resultObject == null)
                    return OperationResult<JobApplicationResponse>.Fail("Job application could not be created. Please try again.", null);

                /* manually map data from dto to new JobApplication instance.*/
                var response = new JobApplicationResponse
                {
                    Id = resultObject.Id,
                    CompanyName = resultObject.CompanyName,
                    RoleTitle = resultObject.RoleTitle,
                    Location = resultObject.Location,
                    StatusId = resultObject.StatusId,
                    MainContactEmail = resultObject.MainContactEmail,
                    MainContactName = resultObject.MainContactName,
                    MainContactPhone = resultObject.MainContactPhone,
                    HiringLikelihoodId = resultObject.HiringLikelihoodId,
                    OpeningDate = resultObject.OpeningDate,
                    DateApplied = resultObject.DateApplied,
                    ClosingDate = resultObject.ClosingDate,
                    SalaryExpectationRange = resultObject.SalaryExpectationRange,
                    RequiredDocumentation = resultObject.RequiredDocumentation,
                    IsClosed = resultObject.IsClosed,
                    Notes = resultObject.Notes,
                    CreatedAt = resultObject.CreatedAt,
                    UpdatedAt = resultObject.UpdatedAt

                };

                return OperationResult<JobApplicationResponse>.Success(response, "Job Application successfully created.");
            }
            catch (Exception ex)
            {
                return OperationResult<JobApplicationResponse>.Fail($"An error occurred: {ex.Message}");
            }
        }

        public async Task<OperationResult<JobApplicationResponse>> UpdateJobApplicationAsync(Guid id, UpdateJobApplicationRequest jobApplication)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(jobApplication.CompanyName))
                    return OperationResult<JobApplicationResponse>.Fail("Company name is required.", null);

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
                    return OperationResult<JobApplicationResponse>.Fail("Job application could not be updated. Please try again.", null);

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

                return OperationResult<JobApplicationResponse>.Success(response, "Job Application updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult<JobApplicationResponse>.Fail($"An error occurred: {ex.Message}");
            }

            

        }

        public async Task<OperationResult> RemoveJobApplicationAsync(Guid id)
        {
            try
            {
                var response = await _repository.RemoveJobApplicationAsync(id);

                if (!response)
                    return OperationResult.Fail("Job application could not be deleted.");

                return OperationResult.Success("Job Application deleted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail($"An error occurred: {ex.Message}");
            }
        }

    }
}
