using AHFS.Models;
namespace AHFS.Services.Interfaces
{
    public interface IDocumentService
    {
        void CreateDocument(Document document);

        void DeleteDocument(Document document);

        void UpdateDocument(Document document);

        Document GetDocumentById(int id);

        List<Document> GetDocuments();

    }
}

