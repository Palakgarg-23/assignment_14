using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmpclassesController : Controller
    {
        private readonly EmpContext _context;

        public EmpclassesController(EmpContext context)
        {
            _context = context;
        }

        // GET: Empclasses
        public async Task<IActionResult> Index()
        {
              return _context.Empclass != null ? 
                          View(await _context.Empclass.ToListAsync()) :
                          Problem("Entity set 'EmpContext.Empclass'  is null.");
        }

        // GET: Empclasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empclass == null)
            {
                return NotFound();
            }

            var empclass = await _context.Empclass
                .FirstOrDefaultAsync(m => m.EId == id);
            if (empclass == null)
            {
                return NotFound();
            }

            return View(empclass);
        }

        // GET: Empclasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empclasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EId,EName,EDesignation,EDoj")] Empclass empclass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empclass);
        }

        // GET: Empclasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empclass == null)
            {
                return NotFound();
            }

            var empclass = await _context.Empclass.FindAsync(id);
            if (empclass == null)
            {
                return NotFound();
            }
            return View(empclass);
        }

        // POST: Empclasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EId,EName,EDesignation,EDoj")] Empclass empclass)
        {
            if (id != empclass.EId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empclass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpclassExists(empclass.EId))
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
            return View(empclass);
        }

        // GET: Empclasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empclass == null)
            {
                return NotFound();
            }

            var empclass = await _context.Empclass
                .FirstOrDefaultAsync(m => m.EId == id);
            if (empclass == null)
            {
                return NotFound();
            }

            return View(empclass);
        }

        // POST: Empclasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empclass == null)
            {
                return Problem("Entity set 'EmpContext.Empclass'  is null.");
            }
            var empclass = await _context.Empclass.FindAsync(id);
            if (empclass != null)
            {
                _context.Empclass.Remove(empclass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpclassExists(int id)
        {
          return (_context.Empclass?.Any(e => e.EId == id)).GetValueOrDefault();
        }
    }
}
