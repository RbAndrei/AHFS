using AHFS.Data;
using AHFS.Repositories.Interfaces;
namespace AHFS.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        protected ApplicationDbContext _applicationDbContext {  get; set; }
        public RepositoryWrapper(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }

        private IStudentRepository? _studentRepository;
        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    _studentRepository = new StudentRepository(_applicationDbContext);
                }
                return _studentRepository;
            }
        }

        private ITeacherRepository? _teacherRepository;
        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (_teacherRepository == null)
                {
                    _teacherRepository = new TeacherRepository(_applicationDbContext);
                }
                return _teacherRepository;
            }
        }

        private IGradeRepository? _gradeRepository;
        public IGradeRepository GradeRepository
        {
            get
            {
                if (_gradeRepository == null)
                {
                    _gradeRepository = new GradeRepository(_applicationDbContext);
                }
                return _gradeRepository;
            }
        }

        private IDocumentRepository? _documentRepository;
        public IDocumentRepository DocumentRepository
        {
            get
            {
                if (_documentRepository == null)
                {
                    _documentRepository = new DocumentRepository(_applicationDbContext);
                }
                return _documentRepository;
            }
        }

        private ISubjectRepository? _subjectRepository;
        public ISubjectRepository SubjectRepository
        {
            get
            {
                if (_subjectRepository == null)
                {
                    _subjectRepository = new SubjectRepository(_applicationDbContext);
                }
                return _subjectRepository;
            }
        }

        private IUserRepository? _userRepository;
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_applicationDbContext);
                }
                return _userRepository;
            }
        }
    }
}
