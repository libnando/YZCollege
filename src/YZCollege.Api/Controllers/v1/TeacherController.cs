using Microsoft.AspNetCore.Mvc;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Request.Query;
using YZCollege.Domain.Dtos.Response;

namespace YZCollege.Api.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        /// <summary>
        /// Comment doc... (https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments)
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TeacherPostRequestDto request)
        {
            var success = await _service.AddAsync(request);

            return StatusCode(success ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody] TeacherPutRequestDto request)
        {
            var success = await _service.UpdateAsync(request);

            return StatusCode(success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest);
        }
    }
}