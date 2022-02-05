using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cmn.std.Log;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDeConcepto.Api.Models;

namespace PruebaDeConcepto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly GestorLog _gestorLog;

        public PaisController(ApplicationDbContext context, GestorLog gestorLog)
        {
            _context = context;
            _gestorLog = gestorLog;
        }

        // GET: api/Pais
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPais()
        {
            _gestorLog.Entrar();
            _gestorLog.Salir();
            return await _context.Pais.ToListAsync();

        }

        // GET: api/Pais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(Guid id)
        {
            var pais = await _context.Pais.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Pais/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(Guid id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
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

        // POST: api/Pais
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            _context.Pais.Add(pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPais", new { id = pais.Id }, pais);
        }

        // DELETE: api/Pais/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pais>> DeletePais(Guid id)
        {
            var pais = await _context.Pais.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            _context.Pais.Remove(pais);
            await _context.SaveChangesAsync();

            return pais;
        }

        private bool PaisExists(Guid id)
        {
            return _context.Pais.Any(e => e.Id == id);
        }
    }
}
