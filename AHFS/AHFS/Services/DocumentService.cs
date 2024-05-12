using AHFS.Repositories.Interfaces;
using AHFS.Services.Interfaces;
using AHFS.Models;

namespace AHFS.Services
{
    public class DocumentService: IDocumentService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public DocumentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateDocument(Document document)
        {
            _repositoryWrapper.DocumentRepository.Create(document);
            _repositoryWrapper.Save();
        }

        public void DeleteDocument(Document document)
        {
            _repositoryWrapper.DocumentRepository.Delete(document);
            _repositoryWrapper.Save();
        }

        public void UpdateDocument(Document document)
        {
            _repositoryWrapper.DocumentRepository.Update(document);
            _repositoryWrapper.Save();
        }

        public Document GetDocumentById(int id)
        {
            return _repositoryWrapper.DocumentRepository.FindByCondition(c => c.DocumentId == id).FirstOrDefault()!;
        }

        public List<Document> GetDocuments()
        {
            return _repositoryWrapper.DocumentRepository.FindAll().ToList();
        }
        public List<Document> GetDocumentsByUserId(string id)
        {
            return _repositoryWrapper.DocumentRepository.FindByCondition(c => c.UserId == id).ToList()!;
        }

    }
}
