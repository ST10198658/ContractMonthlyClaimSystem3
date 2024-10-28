using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContractMonthlyClaimSystem.Data;
using ContractMonthlyClaimSystem.Models;

namespace ContractMonthlyClaimSystem.Controllers
{
    public class LecturersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lecturers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lecturer.ToListAsync());
        }

        // GET: Lecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }

            return View(lecturers);
        }

        // GET: Lecturers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lecturers lecturers)
        {
            lecturers.CreatedById = "Kamogelo";
            lecturers.CreatedOn = DateTime.Now;
            lecturers.ModifiedById = "Kamogelo";
            lecturers.ModifiedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(lecturers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecturers);
        }

        // GET: Lecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturer.FindAsync(id);
            if (lecturers == null)
            {
                return NotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,FirstName,LastName,Phone,Email,Country,DateOfBirth,Address,Department,Designation,CreatedById,CreatedOn,ModifiedById,ModifiedOn")] Lecturers lecturers)
        {
            if (id != lecturers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecturers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LecturersExists(lecturers.Id))
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
            return View(lecturers);
        }

        // GET: Lecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturers = await _context.Lecturer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecturers == null)
            {
                return NotFound();
            }

            return View(lecturers);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lecturers = await _context.Lecturer.FindAsync(id);
            if (lecturers != null)
            {
                _context.Lecturer.Remove(lecturers);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LecturersExists(int id)
        {
            return _context.Lecturer.Any(e => e.Id == id);
        }
    }
}
