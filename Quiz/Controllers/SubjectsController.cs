using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using Quiz.Models.Entities;

namespace Quiz.Controllers
{
    public class SubjectsController : Controller
    {
        public readonly AppDbContext db;
        public SubjectsController(AppDbContext db) { this.db = db; }
        public async Task<IActionResult> Index()
        {
            var rec = await db.Subjects.ToListAsync();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Subject S)
        {
            var rec = await db.Subjects.FirstOrDefaultAsync(x => x.SubjectID == S.SubjectID);
            if(rec == null)
            {
                await db.Subjects.AddAsync(S);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var rec = await db.Subjects.FindAsync(id);
            return View(rec);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Subject S)
        {
            var rec = await db.Subjects.FirstOrDefaultAsync(x => x.SubjectID == S.SubjectID);
            if( rec != null)
            {
                rec.Name = S.Name;
                rec.Duration = S.Duration;
                rec.Grad = S.Grad;
                db.Subjects.Update(rec);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Subject S)
        {
            var rec = await db.Subjects.FirstAsync(x => x.SubjectID == S.SubjectID);
            db.Subjects.Remove(rec);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
