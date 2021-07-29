using Lesson4EntityFramework.BusinessLogicLayer.Services;
using Lesson4EntityFramework.DataAccessLayer;
using Lesson4EntityFramework.DataAccessLayer.Interfaces;
using Lesson4EntityFramework.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Internship.UnitTests
{
    public class UsersServiceTests
    {
        [Fact]
        public async Task GetAndUpdateTest_OkAsync()
        {
            //Arrange
            var userId = 1;
            var usersRepositoryMock = new Mock<IUsersRepository>();
            usersRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>()))
                .Returns(Task.FromResult(new User
                {
                    Id = userId,
                    FirstName = "test",
                    AddressId = 1
                }));

            usersRepositoryMock.Setup(x => x.UpdateUserEmail(It.IsAny<User>(), It.IsAny<string>()))
                .Verifiable();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Users).Returns(usersRepositoryMock.Object);

            var usersService = new UserService(unitOfWorkMock.Object);

            //Act
            var result = await usersService.GetAndUpdate(userId);

            //Assert
            Assert.Equal(userId, result);

        }

        [Fact]
        public async Task GetAndUpdateTest_Failure()
        {
            //Arrange
            var userId = 1;
            var usersRepositoryMock = new Mock<IUsersRepository>();
            usersRepositoryMock.Setup(x => x.GetUserById(It.IsAny<int>()))
                .Returns(Task.FromResult(default(User)));

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(u => u.Users).Returns(usersRepositoryMock.Object);

            var usersService = new UserService(unitOfWorkMock.Object);

            //Act
            //Assert
            await Assert.ThrowsAsync<Exception>(()=>  usersService.GetAndUpdate(userId));

        }
    }
}
