using AHFS.Repositories.Interfaces;
using AHFS.Services;
using AHFS.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Moq;
using System.Linq.Expressions;
using NUnit.Framework.Legacy;

namespace UnitTests
{
    public class UserTests
    {

        private Mock<IRepositoryWrapper> _mockRepositoryWrapper;
        private Mock<IUserRepository> _mockUserRepository;
        private IUserService _userService;

        [SetUp]
        public void Setup()
        {
            _mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            _mockUserRepository = new Mock<IUserRepository>();

            _mockRepositoryWrapper.Setup(repo => repo.UserRepository).Returns(_mockUserRepository.Object);

            _userService = new UserService(_mockRepositoryWrapper.Object);
        }

        [Test]
        public void GetUserById_UserExists_ReturnsUser()
        {
            // Arrange
            var userId = "0f5f6312-8354-4905-a47b-5448375e79d5";
            var expectedUser = new IdentityUser { Id = userId };

            _mockUserRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<IdentityUser, bool>>>()))
                .Returns(new List<IdentityUser> { expectedUser }.AsQueryable());

            // Act
            var result = _userService.GetUserById(userId);

            // Assert
            ClassicAssert.AreEqual(expectedUser.Id, result.Id);         
        }

        [Test]
        public void GetUserById_UserDoesNotExist_ReturnsNull()
        {
            // Arrange
            var userId = "non-existent-id";

            _mockUserRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<IdentityUser, bool>>>()))
                .Returns(Enumerable.Empty<IdentityUser>().AsQueryable());

            // Act
            var result = _userService.GetUserById(userId);

            // Assert
            ClassicAssert.IsNull(result);
        }

        [Test]
        public void CreateUser_ValidUser_CallsCreateAndSave()
        {
            // Arrange
            var newUser = new IdentityUser { Id = "new-id" };

            _mockUserRepository.Setup(repo => repo.Create(It.IsAny<IdentityUser>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _userService.CreateUser(newUser);

            // Assert
            _mockUserRepository.Verify(repo => repo.Create(It.Is<IdentityUser>(u => u.Id == newUser.Id)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void DeleteUser_ValidUser_CallsDeleteAndSave()
        {
            // Arrange
            var user = new IdentityUser { Id = "existing-id" };

            _mockUserRepository.Setup(repo => repo.Delete(It.IsAny<IdentityUser>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _userService.DeleteUser(user);

            // Assert
            _mockUserRepository.Verify(repo => repo.Delete(It.Is<IdentityUser>(u => u.Id == user.Id)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void UpdateUser_ValidUser_CallsUpdateAndSave()
        {
            // Arrange
            var user = new IdentityUser { Id = "existing-id" };

            _mockUserRepository.Setup(repo => repo.Update(It.IsAny<IdentityUser>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _userService.UpdateUser(user);

            // Assert
            _mockUserRepository.Verify(repo => repo.Update(It.Is<IdentityUser>(u => u.Id == user.Id)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void GetUsers_ReturnsListOfUsers()
        {
            // Arrange
            var users = new List<IdentityUser>
            {
                new IdentityUser { Id = "user1" },
                new IdentityUser { Id = "user2" }
            };

            _mockUserRepository.Setup(repo => repo.FindAll()).Returns(users.AsQueryable());

            // Act
            var result = _userService.GetUsers();

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
        }
    }
}
