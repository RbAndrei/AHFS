using AHFS.Models;
namespace AHFS.Services.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(Student student);

        void DeleteStudent(Student student);

        void UpdateStudent(Student student);

        Student GetStudentById(int id);
        List<Student> GetStudents();
    }
}

