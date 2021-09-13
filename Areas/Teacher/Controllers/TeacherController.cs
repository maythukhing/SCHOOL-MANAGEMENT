using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT.Data;
using SCHOOL_MANAGEMENT.Data.DataModel.Teacher;

namespace SCHOOL_MANAGEMENT.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teacher/Teacher
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teacher.ToListAsync());
        }

        // GET: Teacher/Teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModel = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherModel == null)
            {
                return NotFound();
            }

            return View(teacherModel);
        }

        // GET: Teacher/Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Teacher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Ph_Number,DOB,Address")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherModel);
        }

        // GET: Teacher/Teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModel = await _context.Teacher.FindAsync(id);
            if (teacherModel == null)
            {
                return NotFound();
            }
            return View(teacherModel);
        }

        // POST: Teacher/Teacher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RowVersion,CreatedDate,Name,Ph_Number,DOB,Address")] TeacherModel teacherModel)
        {
            if (id != teacherModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherModelExists(teacherModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacherModel);
        }

        // GET: Teacher/Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherModel = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherModel == null)
            {
                return NotFound();
            }

            return View(teacherModel);
        }

        // POST: Teacher/Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherModel = await _context.Teacher.FindAsync(id);
            _context.Teacher.Remove(teacherModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherModelExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
