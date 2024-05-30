using AHFS.Models;
using AHFS.Repositories.Interfaces;
using AHFS.Services;
using AHFS.Services.Interfaces;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitTests
{
    public class StudentServiceTests
    {
        private Mock<IRepositoryWrapper> _mockRepositoryWrapper;
        private Mock<IStudentRepository> _mockStudentRepository;
        private IStudentService _studentService;

        [SetUp]
        public void Setup()
        {
            _mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            _mockStudentRepository = new Mock<IStudentRepository>();

            _mockRepositoryWrapper.Setup(repo => repo.StudentRepository).Returns(_mockStudentRepository.Object);

            _studentService = new StudentService(_mockRepositoryWrapper.Object);
        }

        [Test]
        public void CreateStudent_ValidStudent_CallsCreateAndSave()
        {
            // Arrange
            var newStudent = new Student { StudentId = 1, UserId = "user-id" };

            _mockStudentRepository.Setup(repo => repo.Create(It.IsAny<Student>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _studentService.CreateStudent(newStudent);

            // Assert
            _mockStudentRepository.Verify(repo => repo.Create(It.Is<Student>(s => s.StudentId == newStudent.StudentId)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void DeleteStudent_ValidStudent_CallsDeleteAndSave()
        {
            // Arrange
            var student = new Student { StudentId = 1, UserId = "user-id" };

            _mockStudentRepository.Setup(repo => repo.Delete(It.IsAny<Student>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _studentService.DeleteStudent(student);

            // Assert
            _mockStudentRepository.Verify(repo => repo.Delete(It.Is<Student>(s => s.StudentId == student.StudentId)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void UpdateStudent_ValidStudent_CallsUpdateAndSave()
        {
            // Arrange
            var student = new Student { StudentId = 1, UserId = "user-id" };

            _mockStudentRepository.Setup(repo => repo.Update(It.IsAny<Student>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _studentService.UpdateStudent(student);

            // Assert
            _mockStudentRepository.Verify(repo => repo.Update(It.Is<Student>(s => s.StudentId == student.StudentId)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void GetStudentById_StudentExists_ReturnsStudent()
        {
            // Arrange
            var studentId = 1;
            var expectedStudent = new Student { StudentId = studentId, UserId = "user-id" };

            _mockStudentRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Student, bool>>>()))
                .Returns(new List<Student> { expectedStudent }.AsQueryable());

            // Act
            var result = _studentService.GetStudentById(studentId);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedStudent.StudentId, result.StudentId);
        }

        [Test]
        public void GetStudentByUserId_StudentExists_ReturnsStudent()
        {
            // Arrange
            var userId = "user-id";
            var expectedStudent = new Student { StudentId = 1, UserId = userId };

            _mockStudentRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Student, bool>>>()))
                .Returns(new List<Student> { expectedStudent }.AsQueryable());

            // Act
            var result = _studentService.GetStudentByUserId(userId);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedStudent.UserId, result.UserId);
        }

        [Test]
        public void GetStudentById_StudentDoesNotExist_ReturnsNull()
        {
            // Arrange
            var studentId = 1;

            _mockStudentRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Student, bool>>>()))
                .Returns(Enumerable.Empty<Student>().AsQueryable());

            // Act
            var result = _studentService.GetStudentById(studentId);

            // Assert
            ClassicAssert.IsNull(result);
        }

        [Test]
        public void GetStudentByUserId_StudentDoesNotExist_ReturnsNull()
        {
            // Arrange
            var userId = "non-existent-user-id";

            _mockStudentRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Student, bool>>>()))
                .Returns(Enumerable.Empty<Student>().AsQueryable());

            // Act
            var result = _studentService.GetStudentByUserId(userId);

            // Assert
            ClassicAssert.IsNull(result);
        }

        [Test]
        public void GetStudents_ReturnsListOfStudents()
        {
            // Arrange
            var students = new List<Student>
            {
                new Student { StudentId = 1, UserId = "user1" },
                new Student { StudentId = 2, UserId = "user2" }
            };

            _mockStudentRepository.Setup(repo => repo.FindAll()).Returns(students.AsQueryable());

            // Act
            var result = _studentService.GetStudents();

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.AreEqual("user1", result[0].UserId);
            ClassicAssert.AreEqual("user2", result[1].UserId);
        }
    }
}
