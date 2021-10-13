using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Legal.Backend.Core.Entities;
using Legal.Backend.Core.Repositories;

namespace Legal.Backend.Infrastructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private PostgreSQLContext _context;

        public DocumentTypeRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAsync(DocumentType documentType)
        {
            using (var db = _context.CreateConnection())
            {
                 var sql = @"
                    DELETE
                    FROM document_types
                    WHERE id = @Id
                ";
                var result = await db.ExecuteAsync(sql, new { Id = documentType.Id });
                return result > 0;
            }
        }

        public async Task<IEnumerable<DocumentType>> GetAllAsync()
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        SELECT id, process, name, subdocument, control_medium
                        FROM document_types
                    ";
                return await db.QueryAsync<DocumentType>(sql, new { });
            }
        }

        public async Task<DocumentType> GetAsync(int id)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        SELECT id, process, name, subdocument, control_medium
                        FROM document_types
                        WHERE id = @Id
                    ";
                return await db.QueryFirstOrDefaultAsync<DocumentType>(sql, new { Id = id });
            }
        }

        public async Task<bool> InsertAsync(DocumentType documentType)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        INSERT INTO 
                            document_types(process, name, subdocument, control_medium)
                        VALUES (@Process, @Name, @Subdocument, @ControlMedium)
                    ";
                var result = await db.ExecuteAsync(sql, new { documentType.Process, documentType.Name, documentType.Subdocument, documentType.ControlMedium });
                return result > 0;
            }
        }

        public async Task<bool> UpdateAsync(DocumentType documentType)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        UPDATE document_types SET
                            process = @Process,
                            name = @Name,
                            subdocument = @Subdocument,
                            control_medium = @ControlMedium
                        WHERE id = @Id
                    ";
                var result = await db.ExecuteAsync(sql, new { documentType.Process, documentType.Name, documentType.Subdocument, documentType.ControlMedium, documentType.Id });
                return result > 0;
            }
        }
    }
}