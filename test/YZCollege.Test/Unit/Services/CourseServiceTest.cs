using FluentAssertions;
using Moq;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Entities;
using YZCollege.Domain.Services;

namespace YZCollege.Test.Unit.Services
{
    public class CourseServiceTest
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly ICourseService _courseService;

        public CourseServiceTest() {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseService = new CourseService(_courseRepositoryMock.Object);
        }

        [Fact(DisplayName = "Should create item")]
        public async Task Add_Item_ShouldReturnTrue()
        {
            // arrange
            var command = new CoursePostRequestDto(){ Name = "aaa", Description = "aa", Duration = 9, TeacherId = 1 };

            _courseRepositoryMock.Setup(r => r.SaveAsync(It.IsAny<Course>())).Returns(Task.FromResult(true));

            // act
            var success = await _courseService.AddAsync(command);

            // assert
            success.Should().BeTrue();
        }

    }
}
