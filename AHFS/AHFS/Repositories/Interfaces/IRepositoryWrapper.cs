namespace AHFS.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITeacherRepository TeacherRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        IGradeRepository GradeRepository { get; }
        IStudentRepository StudentRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
    }
}
