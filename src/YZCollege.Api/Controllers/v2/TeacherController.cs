using Microsoft.AspNetCore.Mvc;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;

namespace YZCollege.Api.Controllers.v2
{
    //[ApiController]
    //[Route("v2/[controller]")]
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TeacherPostV2RequestDto request)
        {
            await _service.AddAsync(request);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}