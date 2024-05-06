using AHFS.Repositories.Interfaces;
using AHFS.Services.Interfaces;
using AHFS.Models;

namespace AHFS.Services
{
    public class GradeService: IGradeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GradeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateGrade(Grade grade)
        {
            _repositoryWrapper.GradeRepository.Create(grade);
            _repositoryWrapper.Save();
        }

        public void DeleteGrade(Grade grade)
        {
            _repositoryWrapper.GradeRepository.Delete(grade);
            _repositoryWrapper.Save();
        }

        public void UpdateGrade(Grade grade)
        {
            _repositoryWrapper.GradeRepository.Update(grade);
            _repositoryWrapper.Save();
        }

        public Grade GetGradeById(int id)
        {
            return _repositoryWrapper.GradeRepository.FindByCondition(c => c.GradeId == id).FirstOrDefault()!;
        }

        public List<Grade> GetGrades()
        {
            return _repositoryWrapper.GradeRepository.FindAll().ToList();
        }

    }
}
