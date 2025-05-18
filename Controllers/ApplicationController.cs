using JobMap.API.Models.DTOs.JobApplication;
using JobMap.API.Persistence.Data;
using JobMap.API.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobMap.API.Controllers
{
    [Route("api/jobapplication")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _service;

        public ApplicationController(IApplicationService service)
        {
            _service = service;
        }

        [HttpGet]
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
        [Route("{id:Guid}")]
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

        [HttpPut]
        public async Task<IActionResult> UpdateJobApplication(Guid id, UpdateJobApplicationCommand model)
        {
            try
            {
                var response = await _service.UpdateJobApplicationAsync(id, model);

                if (response == null) 
                    return BadRequest(
                        new { 
                               message = "Bad Request, could not update job application."                               
                             });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error. Please Contact Support. " + ex.Message);
            }
        }

        [HttpDelete]
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
