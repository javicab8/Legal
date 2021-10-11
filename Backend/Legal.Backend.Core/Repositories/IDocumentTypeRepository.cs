using System.Collections.Generic;
using System.Threading.Tasks;
using Legal.Backend.Core.Model;

namespace Legal.Backend.Core.Repositories
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