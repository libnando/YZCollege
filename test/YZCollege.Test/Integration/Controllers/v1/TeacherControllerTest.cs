using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Test.Integration.Common;

namespace YZCollege.Test.Integration.Controllers.v1
{
    public class TeacherControllerTest : IClassFixture<WebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebAppFactory<Program> _factory;
        private const string _route = "/v1/teacher";

        public TeacherControllerTest(WebAppFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions());
        }

        [Fact(DisplayName = "Should return the status 'created' when create item")]
        public async Task Post_Item_ShouldReturnStatusCreated()
        {
            //Arrange
            var command = new TeacherPostRequestDto(){ Name = "James Hetfield" };

            //Act
            var response = await _client.PostAsJsonAsync(_route, command);
        
            //Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

    }
}
