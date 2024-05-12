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

        List<Subject> GetSubjectsByStudentInfo(string faculty, int year);

        List<Subject> GetSubjectsByTeacherId(int id);
    }
}

