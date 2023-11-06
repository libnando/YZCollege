using FluentAssertions;
using Moq;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Entities;
using YZCollege.Domain.Services;

namespace YZCollege.Test.Unit.Services
{
    public class TeacherServiceTest
    {
        private readonly Mock<ITeacherRepository> _teacherRepositoryMock;
        private readonly ITeacherService _teacherService;

        public TeacherServiceTest() {
            _teacherRepositoryMock = new Mock<ITeacherRepository>();
            _teacherService = new TeacherService(_teacherRepositoryMock.Object);
        }

        [Fact(DisplayName = "Should create item")]
        public async Task Add_Item_ShouldReturnTrue()
        {
            // arrange
            var command = new TeacherPostRequestDto(){  Name = "Travis Barker" };

            _teacherRepositoryMock.Setup(r => r.SaveAsync(It.IsAny<Teacher>())).Returns(Task.FromResult(true));

            // act
            var success = await _teacherService.AddAsync(command);

            // assert
            success.Should().BeTrue();
        }

    }
}
