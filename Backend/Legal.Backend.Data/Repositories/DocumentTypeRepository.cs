using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Legal.Backend.Model;
using Npgsql;

namespace Legal.Backend.Data.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private PostgreSQLConfiguration _postgreSQLConnection;

        public DocumentTypeRepository(PostgreSQLConfiguration connectionString)
        {
            _postgreSQLConnection = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_postgreSQLConnection.ConnectionString);
        }
        
        public async Task<bool> DeleteDocumentType(DocumentType documentType)
        {
            var db = dbConnection();
            var sql = @"
                    DELETE
                    FROM document_types
                    WHERE id = @Id
                ";
            var result = await db.ExecuteAsync(sql, new { Id = documentType.Id });
            return result > 0;
        }

        public async Task<IEnumerable<DocumentType>> GetAllDocumentTypes()
        {
            var db = dbConnection();
            var sql = @"
                    SELECT id, process, name, subdocument, control_medium
                    FROM document_types
                ";
            return await db.QueryAsync<DocumentType>(sql, new { });
        }

        public async Task<DocumentType> GetDocumentType(int id)
        {
            var db = dbConnection();
            var sql = @"
                    SELECT id, process, name, subdocument, control_medium
                    FROM document_types
                    WHERE id = @Id
                ";
            return await db.QueryFirstOrDefaultAsync<DocumentType>(sql, new { Id = id });
        }

        public async Task<bool> InsertDocumentType(DocumentType documentType)
        {
            var db = dbConnection();
            var sql = @"
                    INSERT INTO 
                        document_types(process, name, subdocument, control_medium)
                    VALUES (@Process, @Name, @Subdocument, @ControlMedium)
                ";
            var result = await db.ExecuteAsync(sql, new { documentType.Process, documentType.Name, documentType.Subdocument, documentType.ControlMedium });
            return result > 0;
        }

        public async Task<bool> UpdateDocumentType(DocumentType documentType)
        {
            var db = dbConnection();
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