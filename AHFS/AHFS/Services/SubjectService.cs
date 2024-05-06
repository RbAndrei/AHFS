using AHFS.Repositories.Interfaces;
using AHFS.Services.Interfaces;
using AHFS.Models;

namespace AHFS.Services
{
    public class SubjectService: ISubjectService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public SubjectService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateSubject(Subject subject)
        {
            _repositoryWrapper.SubjectRepository.Create(subject);
            _repositoryWrapper.Save();
        }

        public void DeleteSubject(Subject subject)
        {
            _repositoryWrapper.SubjectRepository.Delete(subject);
            _repositoryWrapper.Save();
        }

        public void UpdateSubject(Subject subject)
        {
            _repositoryWrapper.SubjectRepository.Update(subject);
            _repositoryWrapper.Save();
        }

        public Subject GetSubjectById(int id)
        {
            return _repositoryWrapper.SubjectRepository.FindByCondition(c => c.SubjectId == id).FirstOrDefault()!;
        }

        public List<Subject> GetSubjectByName(string Name)
        {
            return _repositoryWrapper.SubjectRepository.FindByCondition(c => c.Name == Name).ToList();
        }

        public List<Subject> GetSubjects()
        {
            return _repositoryWrapper.SubjectRepository.FindAll().ToList();
        }

    }
}
