using API.Controllers;
using Abstractions.DTOs;
using Business;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace API.Tests
{
    public class DataControllerTests
    {
        private readonly IFixture _fixture = new Fixture();
        private readonly ITeacherService _teacherService = Mock.Of<ITeacherService>();

        [Fact]
        public async Task GetSqlTeachers_ReturnsOk_WhenTeachersExist()
        {
            // Arrange
            var teachers = _fixture.Create<IEnumerable<TeacherDto>>();
            Mock.Get(_teacherService).Setup(s => s.GetSqlTeachersAsync()).ReturnsAsync(teachers);

            var controller = new DataController(_teacherService);

            //Act
            var actual = await controller.GetSqlTeachers();

            //Assert
            Assert.NotNull(actual);
            var actualType = Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public async Task WhenGetSqlTeachers_Return500InternalError()
        {
            // Arrange
            Mock.Get(_teacherService).Setup(x => x.GetSqlTeachersAsync()).ThrowsAsync(new Exception());

            var controller = new DataController(_teacherService);

            // Act
            var actual = await controller.GetSqlTeachers();

            // Assert
            Assert.NotNull(actual);
            var actualType = Assert.IsType<ObjectResult>(actual);
            Assert.Equal(500, actualType.StatusCode);
        }

        [Fact]
        public async Task GetMongoTeachers_ReturnsOk_WhenTeachersExist()
        {
            // Arrange
            var teachers = _fixture.Create<IEnumerable<TeacherDto>>();
            Mock.Get(_teacherService).Setup(s => s.GetMongoTeachersAsync()).ReturnsAsync(teachers);

            var controller = new DataController(_teacherService);

            //Act
            var actual = await controller.GetMongoTeachers();

            //Assert
            Assert.NotNull(actual);
            var actualType = Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public async Task WhenGetMongoTeachers_Return500InternalError()
        {
            // Arrange
            Mock.Get(_teacherService).Setup(x => x.GetMongoTeachersAsync()).ThrowsAsync(new Exception());

            var controller = new DataController(_teacherService);

            // Act
            var actual = await controller.GetMongoTeachers();

            // Assert
            Assert.NotNull(actual);
            var actualType = Assert.IsType<ObjectResult>(actual);
            Assert.Equal(500, actualType.StatusCode);
        }

        [Fact]
        public async Task GetCombinedTeachers_ReturnsOk_WhenTeachersExist()
        {
            // Arrange
            var teachers = _fixture.Create<IEnumerable<TeacherDto>>();
            Mock.Get(_teacherService).Setup(s => s.GetCombinedTeachersAsync()).ReturnsAsync(teachers);

            var controller = new DataController(_teacherService);

            //Act
            var actual = await controller.GetCombinedTeachers();

            //Assert
            Assert.NotNull(actual);
            var actualType = Assert.IsType<OkObjectResult>(actual);
        }

        [Fact]
        public async Task WhenGetCombinedTeachers_Return500InternalError()
        {
            // Arrange
            Mock.Get(_teacherService).Setup(x => x.GetCombinedTeachersAsync()).ThrowsAsync(new Exception());

            var controller = new DataController(_teacherService);

            // Act
            var actual = await controller.GetCombinedTeachers();

            // Assert
            Assert.NotNull(actual);
            var actualType = Assert.IsType<ObjectResult>(actual);
            Assert.Equal(500, actualType.StatusCode);
        }
    }
}
