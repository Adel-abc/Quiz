using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using Quiz.Models.Entities;

namespace Quiz.Controllers
{
    public class AssingmentsController : Controller
    {
        public readonly AppDbContext db;
        public AssingmentsController(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var rec = await db.Assignments.Include(x => new { x.SubjectID }).Include(x => new {x.TeacherID}).ToListAsync();
            return View(rec);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Assignment A)
        {
            return View();
        }

    }
}
