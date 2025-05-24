using JobMap.API.Models.DTOs.JobApplication;
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
            var operation = await _service.GetJobApplicationsAsync();

            if (operation.IsSuccess)
                return Ok(operation);

            return BadRequest(new { operation.Message });
            
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetJobApplicationById(Guid id)
        {
            var operation = await _service.GetJobApplicationByIdAsync(id);

            if (operation.IsSuccess)
                return Ok(operation);

            return BadRequest(new { operation.Message });
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobApplication([FromForm] CreateJobApplicationRequest model)
        {
            var operation = await _service.CreateJobApplicationAsync(model);

            if (operation.IsSuccess)
                return Ok(operation);

            return BadRequest(new { operation.Message });

        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobApplication(Guid id, UpdateJobApplicationRequest model)
        {
            var operation = await _service.UpdateJobApplicationAsync(id, model);

            if (operation.IsSuccess)
                return Ok(operation);

            return BadRequest(new { operation.Message });

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveJobApplication(Guid id)
        {
            var operation = await _service.RemoveJobApplicationAsync(id);

            if (operation.IsSuccess)
                return Ok(operation);

            return BadRequest(new { operation.Message });
        }

    }
}
