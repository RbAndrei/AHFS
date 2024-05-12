using AHFS.Repositories.Interfaces;
using AHFS.Services.Interfaces;
using AHFS.Models;

namespace AHFS.Services
{
    public class TeacherService: ITeacherService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public TeacherService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateTeacher(Teacher teacher)
        {
            _repositoryWrapper.TeacherRepository.Create(teacher);
            _repositoryWrapper.Save();
        }

        public void DeleteTeacher(Teacher teacher)
        {
            _repositoryWrapper.TeacherRepository.Delete(teacher);
            _repositoryWrapper.Save();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _repositoryWrapper.TeacherRepository.Update(teacher);
            _repositoryWrapper.Save();
        }

        public List<Teacher> GetTeachers()
        {
            return _repositoryWrapper.TeacherRepository.FindAll().ToList();
        }

        public Teacher GetTeacherByUserId(string id)
        {
            return _repositoryWrapper.TeacherRepository.FindByCondition(c => c.UserId == id).FirstOrDefault()!;
        }

        public Teacher GetTeacherById(int id)
        {
            return _repositoryWrapper.TeacherRepository.FindByCondition(c => c.TeacherId == id).FirstOrDefault()!;
        }

    }
}
