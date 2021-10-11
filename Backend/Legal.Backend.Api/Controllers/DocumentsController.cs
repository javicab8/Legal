using System.Threading.Tasks;
using Legal.Backend.Core.Model;
using Legal.Backend.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Legal.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentsController(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocuments()
        {
            return Ok(await _documentRepository.GetAllDocuments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentDetails(int id)
        {
            return Ok(await _documentRepository.GetDocument(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromBody] Document document)
        {
            if (document is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _documentRepository.InsertDocument(document);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocument([FromBody] Document document)
        {
            if (document is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _documentRepository.UpdateDocument(document);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            await _documentRepository.DeleteDocument(new Document { Id =id });
            return NoContent();
        }
    }
}