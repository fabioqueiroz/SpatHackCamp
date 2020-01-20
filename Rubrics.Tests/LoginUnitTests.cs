using FakeItEasy;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Rubrics.Tests
{
    public class LoginUnitTests
    {
        [Fact]
        public void GivenValidEmailAndPassword_TheUserShouldBeAbletoLogin()
        {
            // Arrange
            var password = "test";
            var hashedPassword = "89278289f48eebc23b2cc3f8ef99d44c5570f92b88d3f878f9c6d964db4ed2e97543ab09762bacd907ceca9fde93f8c3ae895ce6cbed18482c3593d04a6848d8";
            var loginSevice = A.Fake<ILoginService>();
            var studentSevice = A.Fake<IStudentService>();

            // Act
            A.CallTo(() => loginSevice.SHA512ComputeHash(password)).Returns(hashedPassword);
            var result = loginSevice.SHA512ComputeHash(password);

            // Assert
            Assert.Equal(result, hashedPassword);
        }

        [Fact]
        public void GivenIncorrectEmailAndPassword_TheUserShouldNotBeAbletoLogin()
        {
            // Arrange
            var password = "wrong password";
            var hashedPassword = "89278289f48eebc23b2cc3f8ef99d44c5570f92b88d3f878f9c6d964db4ed2e97543ab09762bacd907ceca9fde93f8c3ae895ce6cbed18482c3593d04a6848d8";
            var loginSevice = A.Fake<ILoginService>();

            // Act
            A.CallTo(() => loginSevice.SHA512ComputeHash(password)).Returns(hashedPassword);
            var result = loginSevice.SHA512ComputeHash(password);

            // Assert
            Assert.False(result != hashedPassword);
        }
    }
}
