﻿using System;
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
    public class UsersInfoesController : ControllerBase
    {
        private readonly UserMgmtContext _context;

        public UsersInfoesController(UserMgmtContext context)
        {
            _context = context;
        }

        // GET: api/UsersInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersInfo>>> GetUsersInfo()
        {
          if (_context.UsersInfo == null)
          {
              return NotFound();
          }
            return await _context.UsersInfo.ToListAsync();
        }

        // GET: api/UsersInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersInfo>> GetUsersInfo(int id)
        {
          if (_context.UsersInfo == null)
          {
              return NotFound();
          }
            var usersInfo = await _context.UsersInfo.FindAsync(id);

            if (usersInfo == null)
            {
                return NotFound();
            }

            return usersInfo;
        }

        // PUT: api/UsersInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersInfo(int id, UsersInfo usersInfo)
        {
            if (id != usersInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersInfoExists(id))
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

        // POST: api/UsersInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersInfo>> PostUsersInfo(UsersInfo usersInfo)
        {
          if (_context.UsersInfo == null)
          {
              return Problem("Entity set 'UserMgmtContext.UsersInfo'  is null.");
          }
            _context.UsersInfo.Add(usersInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersInfo", new { id = usersInfo.Id }, usersInfo);
        }

        // DELETE: api/UsersInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersInfo(int id)
        {
            if (_context.UsersInfo == null)
            {
                return NotFound();
            }
            var usersInfo = await _context.UsersInfo.FindAsync(id);
            if (usersInfo == null)
            {
                return NotFound();
            }

            _context.UsersInfo.Remove(usersInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersInfoExists(int id)
        {
            return (_context.UsersInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}