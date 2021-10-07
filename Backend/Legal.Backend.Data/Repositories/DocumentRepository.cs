using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Legal.Backend.Model;

namespace Legal.Backend.Data.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private PostgreSQLContext _context;

        public DocumentRepository(PostgreSQLContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteDocument(Document document)
        {
            using (var db = _context.CreateConnection())
            {
                 var sql = @"
                    DELETE
                    FROM documents
                    WHERE id = @Id
                ";
                var result = await db.ExecuteAsync(sql, new { Id = document.Id });
                return result > 0;
            }
        }

        public async Task<IEnumerable<Document>> GetAllDocuments()
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        SELECT
                            id,
                            settlement,
                            register_at::TIMESTAMP AS RegisterAt,
                            applicant,
                            document_type_id AS DocumentTypeId
                        FROM documents
                    ";
                return await db.QueryAsync<Document>(sql, new { });
            }
        }

        public async Task<Document> GetDocument(int id)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        SELECT
                            id,
                            settlement,
                            register_at::TIMESTAMP AS RegisterAt,
                            applicant,
                            document_type_id AS DocumentTypeId
                        FROM documents
                        WHERE id = @Id
                    ";
<<<<<<< HEAD
                return await db.QueryFirstOrDefaultAsync<Document>(sql, new { Id = id });
=======
                var document = await db.QueryFirstOrDefaultAsync<Document>(sql, new { Id = id });
                Console.WriteLine(document.RegisterAt);
                return document;
>>>>>>> cc5507a81d35a972454ddf39ac4a333b6129e6c8
            }
        }

        public async Task<bool> InsertDocument(Document document)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        INSERT INTO 
                            documents(settlement, register_at, applicant, document_type_id)
                        VALUES (@Settlement, @RegisterAt, @Applicant, @DocumentTypeId)
                    ";
                var result = await db.ExecuteAsync(sql, document);
                return result > 0;
            }
        }

        public async Task<bool> UpdateDocument(Document document)
        {
            using (var db = _context.CreateConnection())
            {
                var sql = @"
                        UPDATE documents SET
                            settlement = @Settlement,
                            register_at = @RegisterAt,
                            applicant = @Applicant,
                            document_type_id = @DocumentTypeId
                        WHERE id = @Id
                    ";
                var result = await db.ExecuteAsync(sql, document);
                return result > 0;
            }
        }
    }
}