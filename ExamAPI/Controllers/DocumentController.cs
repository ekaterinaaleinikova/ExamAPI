using ExamAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public DocumentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IEnumerable<Document>> Get()
        {
            return await dbContext.Documents.ToListAsync();
        }

        [HttpPost("AddDocument")]
        public async Task<Document> AddDocument(IFormFile file, int DocumentId)
        {
            Document document = new Document();

            if (file.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    document.Content = ms.ToArray();
                }
            }
            document.Id = DocumentId;

            dbContext.Documents.Add(document);
            await dbContext.SaveChangesAsync();

            return document;
        }

        [HttpGet("GetContentDocumentById")]
        public async Task<IActionResult> GetContentDocumentById(int Id)
        {
            var file = dbContext.Documents.Find(Id);
            return File(file.Content, "application/octet-stream", "file.txt");
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] Document document)
        {
            var findDoc = dbContext.Documents.Find(document.Id);
            if (findDoc == null)
            {
                return BadRequest("Такого документа не существует");
            }
            else
            {
                try
                {
                    findDoc.Type = document.Type;
                    findDoc.CreatedDate = document.CreatedDate;
                    findDoc.CreatedUserId = document.CreatedUserId;
                    findDoc.Name = document.Name;
                    findDoc.Content = document.Content;
                    findDoc.ReceiverUserId = document.ReceiverUserId;
                    dbContext.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int docId)
        {
            try
            {
                var findDoc = dbContext.Documents.Find(docId);
                dbContext.Documents.Remove(findDoc);
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
