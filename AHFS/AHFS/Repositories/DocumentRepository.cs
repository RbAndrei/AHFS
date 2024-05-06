using AHFS.Repositories.Interfaces;
using AHFS.Data;
using AHFS.Repositories;
using AHFS.Models;

namespace AHFS.Repositories
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
