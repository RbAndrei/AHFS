using AHFS.Repositories.Interfaces;
using AHFS.Services.Interfaces;
using AHFS.Models;

namespace AHFS.Services
{
    public class StudentService: IStudentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StudentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateStudent(Student student)
        {
            _repositoryWrapper.StudentRepository.Create(student);
            _repositoryWrapper.Save();
        }

        public void DeleteStudent(Student student)
        {
            _repositoryWrapper.StudentRepository.Delete(student);
            _repositoryWrapper.Save();
        }

        public void UpdateStudent(Student student)
        {
            _repositoryWrapper.StudentRepository.Update(student);
            _repositoryWrapper.Save();
        }

        public Student GetStudentById(int id)
        {
            return _repositoryWrapper.StudentRepository.FindByCondition(c => c.StudentId == id).FirstOrDefault()!;
        }

        public Student GetStudentByUserId(string id)
        {
            return _repositoryWrapper.StudentRepository.FindByCondition(c => c.UserId == id).FirstOrDefault()!;
        }

        public List<Student> GetStudents()
        {
            return _repositoryWrapper.StudentRepository.FindAll().ToList();
        }

    }
}
