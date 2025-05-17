using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Persistence.Data;
using JobMap.API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobMap.API.Controllers
{
    [Route("api/application")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationController(IApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-job-applications")]
        public async Task<IActionResult> GetAllJobApplications()
        {           
            try
            {
                var result = await _service.GetJobApplicationsAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
        }

        [HttpGet]
        [Route("get-job-app-by-id/{id:Guid}")]
        public async Task<IActionResult> GetJobApplicationById(Guid id)
        {
            try
            {
                var result = await _service.GetJobApplicationByIdAsync(id);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }

        }

        [HttpPost]
        [Route("create-job-app")]
        public async Task<IActionResult> CreateJobApplication([FromForm] CreateJobApplicationCommand model)
        {
            try
            {
                var query = await _service.CreateJobApplicationAsync(model);

                return Ok(query);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete-job-app")]
        public async Task<IActionResult> RemoveJobApplication(Guid id)
        {
            try
            {
                var result = await _service.RemoveJobApplicationAsync(id);

                 return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
        }

    }
}
