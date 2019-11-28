using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KaryawanApi.Models;

namespace KaryawanApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KaryawansController : ControllerBase
    {
        private readonly KaryawanContext _context;

        public KaryawansController(KaryawanContext context)
        {
            _context = context;
        }

        // GET: api/Karyawans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Karyawan>>> GetKaryawans()
        {
            return await _context.Karyawans.ToListAsync();
        }

        // GET: api/Karyawans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Karyawan>> GetKaryawan(int id)
        {
            var karyawan = await _context.Karyawans.FindAsync(id);

            if (karyawan == null)
            {
                return NotFound();
            }

            return karyawan;
        }

        // PUT: api/Karyawans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKaryawan(int id, Karyawan karyawan)
        {
            if (id != karyawan.Id)
            {
                return BadRequest();
            }

            _context.Entry(karyawan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KaryawanExists(id))
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

        // POST: api/Karyawans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Karyawan>> PostKaryawan(Karyawan karyawan)
        {
            _context.Karyawans.Add(karyawan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKaryawan", new { id = karyawan.Id }, karyawan);
        }

        // DELETE: api/Karyawans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Karyawan>> DeleteKaryawan(int id)
        {
            var karyawan = await _context.Karyawans.FindAsync(id);
            if (karyawan == null)
            {
                return NotFound();
            }

            _context.Karyawans.Remove(karyawan);
            await _context.SaveChangesAsync();

            return karyawan;
        }

        private bool KaryawanExists(int id)
        {
            return _context.Karyawans.Any(e => e.Id == id);
        }
    }
}
