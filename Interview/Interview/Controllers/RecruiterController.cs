using Interview.AppCore.Contract.Services;
using Interview.AppCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IRecruiterService service;
        public RecruiterController(IRecruiterService service)
        {
            this.service=service;
        }
        [HttpGet("getbyid")]
        public async Task<IActionResult> Getbyid(int id)
        {
            return Ok(await service.GetRecruiterByIdAsync(id));
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllRecruitersAsync());
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(RecruiterRequestModel model)
        {
            if (model !=null)
            {
                return Ok(await service.AddRecruiterAsync(model));
            }
            return BadRequest();

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await service.DeleteRecruiterAsync(id));
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update(RecruiterRequestModel model)
        {
            if (model != null)
            {
                return Ok(await service.UpdateRecruiterAsync(model));
            }
            return BadRequest();
        }
    }
}
