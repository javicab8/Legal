using System.Threading.Tasks;
using Legal.Backend.Core.Repositories;
using Legal.Backend.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Legal.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypesController(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            return Ok(await _documentTypeRepository.GetAllDocumentTypes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentTypeDetails(int id)
        {
            return Ok(await _documentTypeRepository.GetDocumentType(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocumentType([FromBody] DocumentType documentType)
        {
            if (documentType is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _documentTypeRepository.InsertDocumentType(documentType);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDocumentType([FromBody] DocumentType documentType)
        {
            if (documentType is null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _documentTypeRepository.UpdateDocumentType(documentType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            await _documentTypeRepository.DeleteDocumentType(new DocumentType { Id =id });
            return NoContent();
        }
    }
}