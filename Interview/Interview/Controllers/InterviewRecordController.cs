using Interview.AppCore.Contract.Services;
using Interview.AppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewRecordController : ControllerBase
    {
        private readonly IInterviewRecordService service;
        public InterviewRecordController(IInterviewRecordService service)
        {
            this.service=service;
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> Getbyid(int id)
        {
            return Ok(await service.GetInterviewRecordByIdAsync(id));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllInterviewRecordsAsync());
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(InterviewRecordRequestModel model)
        {
            if(model !=null)
            {
                return Ok(await service.AddInterviewRecordAsync(model));
            }
            return BadRequest();

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteInterviewRecordAsync(id));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(InterviewRecordRequestModel model)
        {
            if(model != null)
            {
                return Ok(await service.UpdateInterviewRecordAsync(model));
            }
            return BadRequest();
        }
    }
}
