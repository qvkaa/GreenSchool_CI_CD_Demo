using GreenSchool.Api.Controllers;
using GreenSchool.Core.Repositories;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GreenSchool.Unit.Tests
{
    [Trait("Category", "StudentsControllerTests")]
    public class StudentsControllerTests
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentsController _studentsController;

        public StudentsControllerTests()
        {
            _studentRepository = Substitute.For<IStudentRepository>();
            _studentRepository.GetById(Arg.Any<long>()).ReturnsForAnyArgs(new Models.Student
            {
                FirstName = "first",
                LastName = "last",
                StudentId = 1
            });
            _studentsController = new StudentsController(_studentRepository);
        }

        [Fact(DisplayName ="GetByIdReturnsResult")]
        public async Task GetByIdReturnsResult()
        {
            var expectedResult = "first last 1";
            var result = await _studentsController.Get(1);

            Assert.Equal(expectedResult, result);
        }
    }
}
