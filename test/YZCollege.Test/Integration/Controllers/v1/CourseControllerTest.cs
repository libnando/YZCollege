using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Response;
using YZCollege.Test.Integration.Common;

namespace YZCollege.Test.Integration.Controllers.v1
{
    public class CourseControllerTest : IClassFixture<WebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebAppFactory<Program> _factory;
        private readonly ITeacherService? _teacherService;
        private const string _route = "/v1/course";

        public CourseControllerTest(WebAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
            _teacherService = factory.Services.GetService<ITeacherService>();
        }

        [Fact(DisplayName = "Should return the status 'created' when create item")]
        public async Task Post_Item_ShouldReturnStatusCreated()
        {
            //Arrange
            if (_teacherService is not null)
                await _teacherService.AddAsync(new TeacherPostRequestDto() { Name = "Brian May" });

            var command = new CoursePostRequestDto(){ Name = "Curso X", Description = "aaaa", Duration = 393, TeacherId = 1 };

            //Act
            var response = await _client.PostAsJsonAsync(_route, command);
        
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact(DisplayName = "Should return the status 'ok' when get existing item")]
        public async Task Get_ExistingItem_ShouldReturnStatusOk()
        {
            //Arrange
            if (_teacherService is not null)
                await _teacherService.AddAsync(new TeacherPostRequestDto() { Name = "John Frusciante" });

            var commandRequest = new CoursePostRequestDto() { Name = "Curso X", Description = "aaaa", Duration = 393, TeacherId = 1 };
            var commandQuery = $"Name={commandRequest.Name}";
            
            await _client.PostAsJsonAsync(_route, commandRequest);

            //Act
            var response = await _client.GetAsync($"{_route}?{commandQuery}");
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<IEnumerable<CourseResponseDto>>(responseBody);

            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            responseData?.First().Id.Should().Be(1);
            responseData?.First().Name.Should().Be(commandRequest.Name);
        }

    }
}
