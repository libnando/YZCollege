using Microsoft.AspNetCore.Mvc;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Request.Query;
using YZCollege.Domain.Dtos.Response;
using YZCollege.Domain.Dtos.Validators;

namespace YZCollege.Api.Controllers.v1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] CourseQueryDto filter)
        {
            var response = await _service.FindAllAsync(filter);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] CoursePostRequestDto request)
        {
            //var courseValidation = new CoursePostValidator().Validate(request);

            //if (!courseValidation.IsValid)
            //    return BadRequest(courseValidation.Errors);

            var success = await _service.AddAsync(request);

            return StatusCode(success ? StatusCodes.Status201Created : StatusCodes.Status400BadRequest);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            return StatusCode(success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest);
        }
    }
}