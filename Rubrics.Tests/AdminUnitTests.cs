using FakeItEasy;
using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rubrics.Tests
{
    public class AdminUnitTests
    {
        [Fact]
        public void GivenTheStudentsEmailIsCorrect_TheAdminCanDeleteTheStudent_FromTheDatabase()
        {
            // Arrange
            var email = "student@test.com";
            var studentSevice = A.Fake<IStudentService>();
            var studentRepository = A.Fake<IStudentRepository>();

            var student = new Student
            {
                Email = email
            };

            // Act
            A.CallTo(() => studentSevice.DeleteStudentByEmail(email)).Returns(true);
            var result = studentSevice.DeleteStudentByEmail(email);
            var delStudent = studentRepository.DeleteStudentByEmail(student.Email);

            // Assert
            Assert.True(result);
            Assert.False(delStudent);
            
        }
    }
}
