namespace Goodies.Shop.Tests.Repository.Implementation
{
    using System;
    using System.Threading.Tasks;
    using Goodies.Shop.Database.Context;
    using Goodies.Shop.Database.Entities;
    using Goodies.Shop.Database.Repository.Implementation;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Moq;
    using NSubstitute;
    using Xunit;

    public class UserRepositoryTests
    {
        private UserRepository _testClass;
        private ILogger<UserRepository> _logger;
        private GoodiesContext _goodiesContext;

        public UserRepositoryTests()
        {
            _logger = Substitute.For<ILogger<UserRepository>>();
            _goodiesContext = new GoodiesContext(new DbContextOptions<GoodiesContext>());
            _testClass = new UserRepository(_logger, _goodiesContext);
        }

        [Fact]
        public async Task GetUsersAsync_ReturnsListOfUsers()
        {
            // Arrange
            var usersData = new List<User>
            {
                new User { UserID = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john@example.com", Password = "password1", Cellphone = "1234567890", DateCreated = DateTime.Now },
                new User { UserID = 2, FirstName = "Jane", LastName = "Doe", EmailAddress = "jane@example.com", Password = "password2", Cellphone = "0987654321", DateCreated = DateTime.Now }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<User>>();
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(usersData.Provider);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(usersData.Expression);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(usersData.ElementType);
            mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(usersData.GetEnumerator());

            var mockDbContext = new Mock<GoodiesContext>();
            mockDbContext.Setup(c => c.User).Returns(mockDbSet.Object);

            var userService = new UserRepository(_logger, mockDbContext.Object);

            // Act
            var result = await userService.GetUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].FirstName);
            Assert.Equal("Doe", result[0].LastName);
            Assert.Equal("john@example.com", result[0].EmailAddress);
            Assert.Equal("password1", result[0].Password);
            Assert.Equal("1234567890", result[0].Cellphone);
            Assert.NotNull(result[0].DateCreated);
            Assert.Equal("Jane", result[1].FirstName);
            Assert.Equal("Doe", result[1].LastName);
            Assert.Equal("jane@example.com", result[1].EmailAddress);
            Assert.Equal("password2", result[1].Password);
            Assert.Equal("0987654321", result[1].Cellphone);
            Assert.NotNull(result[1].DateCreated);
        }

    }
}