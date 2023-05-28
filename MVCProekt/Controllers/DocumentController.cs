using ExamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MVCProekt.Controllers
{
    public class DocumentController : Controller
    {
        public ApplicationDbContext context;
        public DocumentController(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public IActionResult Index()
        {
            var docs = context.Documents.ToList();
            return View(docs);
        }

        [HttpPost]
        public IActionResult Create(Document document)
        {
                if (ModelState.IsValid)
                {
                    context.Documents.Add(document);
                    context.SaveChanges();

                    return RedirectToAction("Index", "Home"); 
                }
                
            return View(document);
        }
    }
}
