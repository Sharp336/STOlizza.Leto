﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STOlizza.Leto.Server;
using STOlizza.Leto.Shared;

namespace STOlizza.Leto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmenaDTOesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SmenaDTOesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/SmenaDTOes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmenaDTO>>> GetShifts()
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }
            return await _context.Shifts.ToListAsync();
        }

        // GET: api/SmenaDTOes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmenaDTO>> GetSmenaDTO(int id)
        {
          if (_context.Shifts == null)
          {
              return NotFound();
          }
            var smenaDTO = await _context.Shifts.FindAsync(id);

            if (smenaDTO == null)
            {
                return NotFound();
            }

            return smenaDTO;
        }

        // PUT: api/SmenaDTOes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmenaDTO(int id, SmenaDTO smenaDTO)
        {
            if (id != smenaDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(smenaDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmenaDTOExists(id))
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

        // POST: api/SmenaDTOes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmenaDTO>> PostSmenaDTO(SmenaDTO smenaDTO)
        {
          if (_context.Shifts == null)
          {
              return Problem("Entity set 'DatabaseContext.Shifts'  is null.");
          }
            _context.Shifts.Add(smenaDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmenaDTO", new { id = smenaDTO.Id }, smenaDTO);
        }

        // DELETE: api/SmenaDTOes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmenaDTO(int id)
        {
            if (_context.Shifts == null)
            {
                return NotFound();
            }
            var smenaDTO = await _context.Shifts.FindAsync(id);
            if (smenaDTO == null)
            {
                return NotFound();
            }

            _context.Shifts.Remove(smenaDTO);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmenaDTOExists(int id)
        {
            return (_context.Shifts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
