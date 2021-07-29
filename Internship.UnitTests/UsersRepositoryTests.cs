using Lesson4EntityFramework.DataAccessLayer.Interfaces;
using Lesson4EntityFramework.DataAccessLayer.Repositories;
using Lesson4EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Internship.UnitTests
{
    public class UsersRepositoryTests
    {
        private ApplicationDbContext _dbContext;
        private IUsersRepository _usersRepository;
        public UsersRepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");
            _dbContext = new ApplicationDbContext(optionsBuilder.Options);

            _dbContext = new ApplicationDbContext();
            _usersRepository = new UsersRepository(_dbContext);

        }

        [Fact]
        public async System.Threading.Tasks.Task CreateNewUserTestsAsync()
        {
            //Arrange
            var address = _dbContext.Add(new Address
            {
                Id = 1,
                City = "test"
            }).Entity;
            _dbContext.SaveChanges();


            //Act
            var userId = await _usersRepository.CreateNewUser(address.Id);

            //Assert
            var user = await _usersRepository.GetUserById(userId);
            Assert.NotNull(user);
            Assert.Equal(user.AddressId, address.Id);
        }
    }
}
