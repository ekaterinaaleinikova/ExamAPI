using ExamAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MVCProekt.Controllers
{
    public class UserController : Controller
    {
        public ApplicationDbContext context;
        public UserController(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(user);
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(user);
        }

    }
}

