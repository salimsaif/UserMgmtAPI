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
    public class MediclaimTypesController : ControllerBase
    {
        private readonly UserMgmtContext _context;

        public MediclaimTypesController(UserMgmtContext context)
        {
            _context = context;
        }

        // GET: api/MediclaimTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediclaimType>>> GetMediclaimType()
        {
          if (_context.MediclaimType == null)
          {
              return NotFound();
          }
            return await _context.MediclaimType.ToListAsync();
        }

        // GET: api/MediclaimTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediclaimType>> GetMediclaimType(int id)
        {
          if (_context.MediclaimType == null)
          {
              return NotFound();
          }
            var mediclaimType = await _context.MediclaimType.FindAsync(id);

            if (mediclaimType == null)
            {
                return NotFound();
            }

            return mediclaimType;
        }

        // PUT: api/MediclaimTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediclaimType(int id, MediclaimType mediclaimType)
        {
            if (id != mediclaimType.Id)
            {
                return BadRequest();
            }

            _context.Entry(mediclaimType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediclaimTypeExists(id))
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

        // POST: api/MediclaimTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MediclaimType>> PostMediclaimType(MediclaimType mediclaimType)
        {
          if (_context.MediclaimType == null)
          {
              return Problem("Entity set 'UserMgmtContext.MediclaimType'  is null.");
          }
            _context.MediclaimType.Add(mediclaimType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediclaimType", new { id = mediclaimType.Id }, mediclaimType);
        }

        // DELETE: api/MediclaimTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMediclaimType(int id)
        {
            if (_context.MediclaimType == null)
            {
                return NotFound();
            }
            var mediclaimType = await _context.MediclaimType.FindAsync(id);
            if (mediclaimType == null)
            {
                return NotFound();
            }

            _context.MediclaimType.Remove(mediclaimType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MediclaimTypeExists(int id)
        {
            return (_context.MediclaimType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
