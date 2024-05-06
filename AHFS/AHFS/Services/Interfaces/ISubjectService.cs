using AHFS.Models;
namespace AHFS.Services.Interfaces
{
    public interface ISubjectService
    {
        void CreateSubject(Subject subject);

        void DeleteSubject(Subject subject);

        void UpdateSubject(Subject subject);

        Subject GetSubjectById(int id);

        List<Subject> GetSubjectByName(string SubjectName);

        List<Subject> GetSubjects();
    }
}

