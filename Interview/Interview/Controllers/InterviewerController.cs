using Interview.AppCore.Contract.Services;
using Interview.AppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewerController : ControllerBase
    {
        private readonly IInterviewerService service;
        public InterviewerController(IInterviewerService service)
        {
            this.service=service;
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> Getbyid(int id)
        {
            return Ok(await service.GetInterviewerById(id));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviewersAsync());
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(InterviewerRequestModel model)
        {
            if (model !=null)
            {
                return Ok(await service.AddInterviewerAsync(model));
            }
            return BadRequest();

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewerAsync(id));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewerRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateInterviewerAsync(model));
            }
            return BadRequest();
        }
    }
}
