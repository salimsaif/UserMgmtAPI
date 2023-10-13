using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserMgmt.Data;
using UserMgmt.Model;

namespace UserMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSalariesController : ControllerBase
    {
        private readonly UserMgmtContext _context;

        public UserSalariesController(UserMgmtContext context)
        {
            _context = context;
        }

        // GET: api/UserSalaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSalary>>> GetUserSalary()
        {
          if (_context.UserSalary == null)
          {
              return NotFound();
          }
            return await _context.UserSalary.ToListAsync();
        }

        // GET: api/UserSalaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSalary>> GetUserSalary(int id)
        {
          if (_context.UserSalary == null)
          {
              return NotFound();
          }
            var userSalary = await _context.UserSalary.FindAsync(id);

            if (userSalary == null)
            {
                return NotFound();
            }

            return userSalary;
        }

        // PUT: api/UserSalaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSalary(int id, UserSalary userSalary)
        {
            if (id != userSalary.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSalary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSalaryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserSalaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSalary>> PostUserSalary(UserSalary userSalary)
        {
          if (_context.UserSalary == null)
          {
              return Problem("Entity set 'UserMgmtContext.UserSalary'  is null.");
          }
            _context.UserSalary.Add(userSalary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSalary", new { id = userSalary.Id }, userSalary);
        }

        // DELETE: api/UserSalaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSalary(int id)
        {
            if (_context.UserSalary == null)
            {
                return NotFound();
            }
            var userSalary = await _context.UserSalary.FindAsync(id);
            if (userSalary == null)
            {
                return NotFound();
            }

            _context.UserSalary.Remove(userSalary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSalaryExists(int id)
        {
            return (_context.UserSalary?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
