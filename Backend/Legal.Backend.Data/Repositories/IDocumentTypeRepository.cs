using System.Collections.Generic;
using System.Threading.Tasks;
using Legal.Backend.Model;

namespace Legal.Backend.Data.Repositories
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetAllDocumentTypes();
        Task<DocumentType> GetDocumentType(int id);
        Task<bool> InsertDocumentType(DocumentType documentType);
        Task<bool> UpdateDocumentType(DocumentType documentType);
        Task<bool> DeleteDocumentType(DocumentType documentType);
    }
}