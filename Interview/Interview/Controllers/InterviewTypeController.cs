using Interview.AppCore.Contract.Services;
using Interview.AppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypeController : ControllerBase
    {
        private readonly IInterviewTypeService service;
        public InterviewTypeController(IInterviewTypeService service)
        {
            this.service=service;
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> Getbyid(int id)
        {
            return Ok(await service.GetInterviewTypeByIdAsync(id));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviewTypesAsync());
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(InterviewTypeRequestModel model)
        {
            if (model !=null)
            {
                return Ok(await service.AddInterviewTypeAsync(model));
            }
            return BadRequest();

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewTypeAsync(id));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewTypeRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateInterviewTypeAsync(model));
            }
            return BadRequest();
        }
    }
}
