using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;
using Quiz.Models.Entities;

namespace Quiz.Controllers
{
    public class TeachersController : Controller
    {
        public readonly AppDbContext db;
        public TeachersController(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult>Index()
        {
            var rec = await db.Teachers.ToListAsync();
            return View(rec);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher T)
        {
            await db.Teachers.AddAsync(T);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var rec = await db.Teachers.FindAsync(id);
            return View(rec);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Teacher T)
        {
            var rec = db.Teachers.FirstOrDefault(x => x.TeacherID == T.TeacherID);
            if (rec != null)
            {
                rec.Name = T.Name;
                rec.Email = T.Email;
                rec.Specialization = T.Specialization;
                db.Teachers.Update(rec);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete() {  return View(); }
        [HttpPost]
        public async Task<IActionResult> Delete(Teacher T)
        {
            var rec = await db.Teachers.FirstOrDefaultAsync(x => x.TeacherID == T.TeacherID);
            if(rec != null)
            {
                db.Teachers.Remove(rec);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
