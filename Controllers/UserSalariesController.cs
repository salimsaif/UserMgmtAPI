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
    public class UserSalariesController : Controller
    {
        private readonly UserMgmtContext _context;

        public UserSalariesController(UserMgmtContext context)
        {
            _context = context;
        }

        // GET: UserSalaries
        public async Task<IActionResult> Index()
        {
            var userMgmtContext = _context.UserSalary.Include(u => u.MediclaimType).Include(u => u.UsersInfo);
            return View(await userMgmtContext.ToListAsync());
        }

        // GET: UserSalaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserSalary == null)
            {
                return NotFound();
            }

            var userSalary = await _context.UserSalary
                .Include(u => u.MediclaimType)
                .Include(u => u.UsersInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSalary == null)
            {
                return NotFound();
            }

            return View(userSalary);
        }

        // GET: UserSalaries/Create
        public IActionResult Create()
        {
            ViewData["MediclaimTypeId"] = new SelectList(_context.Set<MediclaimType>(), "Id", "MType");
            ViewData["userId"] = new SelectList(_context.UsersInfo, "Id", "FirstName");
            return View();
        }

        // POST: UserSalaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,userId,Salary,PAN,AccountNumber,HasMediclaim,MediclaimTypeId")] UserSalary userSalary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userSalary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MediclaimTypeId"] = new SelectList(_context.Set<MediclaimType>(), "Id", "MType", userSalary.MediclaimTypeId);
            ViewData["userId"] = new SelectList(_context.UsersInfo, "Id", "FirstName", userSalary.userId);
            return View(userSalary);
        }

        // GET: UserSalaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserSalary == null)
            {
                return NotFound();
            }

            var userSalary = await _context.UserSalary.FindAsync(id);
            if (userSalary == null)
            {
                return NotFound();
            }
            ViewData["MediclaimTypeId"] = new SelectList(_context.Set<MediclaimType>(), "Id", "MType", userSalary.MediclaimTypeId);
            ViewData["userId"] = new SelectList(_context.UsersInfo, "Id", "FirstName", userSalary.userId);
            return View(userSalary);
        }

        // POST: UserSalaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,userId,Salary,PAN,AccountNumber,HasMediclaim,MediclaimTypeId")] UserSalary userSalary)
        {
            if (id != userSalary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userSalary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserSalaryExists(userSalary.Id))
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
            ViewData["MediclaimTypeId"] = new SelectList(_context.Set<MediclaimType>(), "Id", "MType", userSalary.MediclaimTypeId);
            ViewData["userId"] = new SelectList(_context.UsersInfo, "Id", "FirstName", userSalary.userId);
            return View(userSalary);
        }

        // GET: UserSalaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserSalary == null)
            {
                return NotFound();
            }

            var userSalary = await _context.UserSalary
                .Include(u => u.MediclaimType)
                .Include(u => u.UsersInfo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userSalary == null)
            {
                return NotFound();
            }

            return View(userSalary);
        }

        // POST: UserSalaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserSalary == null)
            {
                return Problem("Entity set 'UserMgmtContext.UserSalary'  is null.");
            }
            var userSalary = await _context.UserSalary.FindAsync(id);
            if (userSalary != null)
            {
                _context.UserSalary.Remove(userSalary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserSalaryExists(int id)
        {
          return (_context.UserSalary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
