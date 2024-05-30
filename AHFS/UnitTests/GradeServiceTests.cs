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
    public class GradeServiceTests
    {
        private Mock<IRepositoryWrapper> _mockRepositoryWrapper;
        private Mock<IGradeRepository> _mockGradeRepository;
        private IGradeService _gradeService;

        [SetUp]
        public void Setup()
        {
            _mockRepositoryWrapper = new Mock<IRepositoryWrapper>();
            _mockGradeRepository = new Mock<IGradeRepository>();

            _mockRepositoryWrapper.Setup(repo => repo.GradeRepository).Returns(_mockGradeRepository.Object);

            _gradeService = new GradeService(_mockRepositoryWrapper.Object);
        }

        [Test]
        public void CreateGrade_ValidGrade_CallsCreateAndSave()
        {
            // Arrange
            var newGrade = new Grade { GradeId = 1, StudentId = 1, SubjectId = 1 };

            _mockGradeRepository.Setup(repo => repo.Create(It.IsAny<Grade>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _gradeService.CreateGrade(newGrade);

            // Assert
            _mockGradeRepository.Verify(repo => repo.Create(It.Is<Grade>(g => g.GradeId == newGrade.GradeId)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void DeleteGrade_ValidGrade_CallsDeleteAndSave()
        {
            // Arrange
            var grade = new Grade { GradeId = 1, StudentId = 1, SubjectId = 1 };

            _mockGradeRepository.Setup(repo => repo.Delete(It.IsAny<Grade>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _gradeService.DeleteGrade(grade);

            // Assert
            _mockGradeRepository.Verify(repo => repo.Delete(It.Is<Grade>(g => g.GradeId == grade.GradeId)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void UpdateGrade_ValidGrade_CallsUpdateAndSave()
        {
            // Arrange
            var grade = new Grade { GradeId = 1, StudentId = 1, SubjectId = 1 };

            _mockGradeRepository.Setup(repo => repo.Update(It.IsAny<Grade>()));
            _mockRepositoryWrapper.Setup(repo => repo.Save());

            // Act
            _gradeService.UpdateGrade(grade);

            // Assert
            _mockGradeRepository.Verify(repo => repo.Update(It.Is<Grade>(g => g.GradeId == grade.GradeId)), Times.Once);
            _mockRepositoryWrapper.Verify(repo => repo.Save(), Times.Once);
        }

        [Test]
        public void GetGradeById_GradeExists_ReturnsGrade()
        {
            // Arrange
            var gradeId = 1;
            var expectedGrade = new Grade { GradeId = gradeId, StudentId = 1, SubjectId = 1 };

            _mockGradeRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Grade, bool>>>()))
                .Returns(new List<Grade> { expectedGrade }.AsQueryable());

            // Act
            var result = _gradeService.GetGradeById(gradeId);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedGrade.GradeId, result.GradeId);
        }

        [Test]
        public void GetGradeById_GradeDoesNotExist_ReturnsNull()
        {
            // Arrange
            var gradeId = 1;

            _mockGradeRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Grade, bool>>>()))
                .Returns(Enumerable.Empty<Grade>().AsQueryable());

            // Act
            var result = _gradeService.GetGradeById(gradeId);

            // Assert
            ClassicAssert.IsNull(result);
        }

        [Test]
        public void GetGrades_ReturnsListOfGrades()
        {
            // Arrange
            var grades = new List<Grade>
            {
                new Grade { GradeId = 1, StudentId = 1, SubjectId = 1 },
                new Grade { GradeId = 2, StudentId = 2, SubjectId = 2 }
            };

            _mockGradeRepository.Setup(repo => repo.FindAll()).Returns(grades.AsQueryable());

            // Act
            var result = _gradeService.GetGrades();

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.AreEqual(1, result[0].StudentId);
            ClassicAssert.AreEqual(2, result[1].StudentId);
        }

        [Test]
        public void GetGradesByStudentId_ReturnsListOfGrades()
        {
            // Arrange
            var studentId = 1;
            var grades = new List<Grade>
            {
                new Grade { GradeId = 1, StudentId = studentId, SubjectId = 1 },
                new Grade { GradeId = 2, StudentId = studentId, SubjectId = 2 }
            };

            _mockGradeRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Grade, bool>>>()))
                .Returns(grades.AsQueryable());

            // Act
            var result = _gradeService.GetGradesByStudentId(studentId);

            // Assert
            ClassicAssert.AreEqual(2, result.Count);
            ClassicAssert.AreEqual(studentId, result[0].StudentId);
            ClassicAssert.AreEqual(studentId, result[1].StudentId);
        }

        [Test]
        public void GetGradeBySubjectIdAndStudentId_GradeExists_ReturnsGrade()
        {
            // Arrange
            var subjectId = 1;
            var studentId = 1;
            var expectedGrade = new Grade { GradeId = 1, StudentId = studentId, SubjectId = subjectId };

            _mockGradeRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Grade, bool>>>()))
                .Returns(new List<Grade> { expectedGrade }.AsQueryable());

            // Act
            var result = _gradeService.GetGradeBySubjectIdAndStudentId(subjectId, studentId);

            // Assert
            ClassicAssert.IsNotNull(result);
            ClassicAssert.AreEqual(expectedGrade.GradeId, result.GradeId);
        }

        [Test]
        public void GetGradeBySubjectIdAndStudentId_GradeDoesNotExist_ReturnsNull()
        {
            // Arrange
            var subjectId = 1;
            var studentId = 1;

            _mockGradeRepository
                .Setup(repo => repo.FindByCondition(It.IsAny<Expression<Func<Grade, bool>>>()))
                .Returns(Enumerable.Empty<Grade>().AsQueryable());

            // Act
            var result = _gradeService.GetGradeBySubjectIdAndStudentId(subjectId, studentId);

            // Assert
            ClassicAssert.IsNull(result);
        }
    }
}
