using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserMgmt.Data;
using UserMgmt.Model;

namespace UserMgmt.Controllers
{
    public class MediclaimTypesController : Controller
    {
        private readonly UserMgmtContext _context;

        public MediclaimTypesController(UserMgmtContext context)
        {
            _context = context;
        }

        // GET: MediclaimTypes
        public async Task<IActionResult> Index()
        {
              return _context.MediclaimType != null ? 
                          View(await _context.MediclaimType.ToListAsync()) :
                          Problem("Entity set 'UserMgmtContext.MediclaimType'  is null.");
        }

        // GET: MediclaimTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MediclaimType == null)
            {
                return NotFound();
            }

            var mediclaimType = await _context.MediclaimType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediclaimType == null)
            {
                return NotFound();
            }

            return View(mediclaimType);
        }

        // GET: MediclaimTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediclaimTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MType")] MediclaimType mediclaimType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediclaimType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediclaimType);
        }

        // GET: MediclaimTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MediclaimType == null)
            {
                return NotFound();
            }

            var mediclaimType = await _context.MediclaimType.FindAsync(id);
            if (mediclaimType == null)
            {
                return NotFound();
            }
            return View(mediclaimType);
        }

        // POST: MediclaimTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MType")] MediclaimType mediclaimType)
        {
            if (id != mediclaimType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediclaimType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediclaimTypeExists(mediclaimType.Id))
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
            return View(mediclaimType);
        }

        // GET: MediclaimTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MediclaimType == null)
            {
                return NotFound();
            }

            var mediclaimType = await _context.MediclaimType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediclaimType == null)
            {
                return NotFound();
            }

            return View(mediclaimType);
        }

        // POST: MediclaimTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MediclaimType == null)
            {
                return Problem("Entity set 'UserMgmtContext.MediclaimType'  is null.");
            }
            var mediclaimType = await _context.MediclaimType.FindAsync(id);
            if (mediclaimType != null)
            {
                _context.MediclaimType.Remove(mediclaimType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediclaimTypeExists(int id)
        {
          return (_context.MediclaimType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
