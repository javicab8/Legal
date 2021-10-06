using System.Collections.Generic;
using System.Threading.Tasks;
using Legal.Backend.Model;

namespace Legal.Backend.Data.Repositories
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAllDocuments();
        Task<Document> GetDocument(int id);
        Task<bool> InsertDocument(Document document);
        Task<bool> UpdateDocument(Document document);
        Task<bool> DeleteDocument(Document document);
    }
}