using AHFS.Models;
namespace AHFS.Services.Interfaces
{
    public interface IGradeService
    {
        void CreateGrade(Grade grade);

        void DeleteGrade(Grade grade);

        void UpdateGrade(Grade grade);

        Grade GetGradeById(int id);

        List<Grade> GetGrades();

        List<Grade> GetGradesByStudentId(int id);

        Grade GetGradeBySubjectIdAndStudentId(int subjectId, int studentId);


    }
}

