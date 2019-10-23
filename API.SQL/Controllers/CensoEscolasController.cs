using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.SQL.Models;
using SharedLibrary;

namespace API.SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CensoEscolasController : ControllerBase
    {
        private readonly CensoEscolaContext _context;

        public CensoEscolasController(CensoEscolaContext context)
        {
            _context = context;
        }

        // GET: api/CensoEscolas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CensoEscola>>> GetCensosEscolas()
        {
            return await _context.CensosEscolas.ToListAsync();
        }

        // GET: api/CensoEscolas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CensoEscola>> GetCensoEscola(int id)
        {
            var censoEscola = await _context.CensosEscolas.FindAsync(id);

            if (censoEscola == null)
            {
                return NotFound();
            }

            return censoEscola;
        }

        // PUT: api/CensoEscolas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCensoEscola(int id, CensoEscola censoEscola)
        {
            if (id != censoEscola.Ano)
            {
                return BadRequest();
            }

            _context.Entry(censoEscola).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CensoEscolaExists(id))
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

        // POST: api/CensoEscolas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CensoEscola>> PostCensoEscola(CensoEscola censoEscola)
        {
            _context.CensosEscolas.Add(censoEscola);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CensoEscolaExists(censoEscola.Ano))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction(nameof(GetCensoEscola), new { id = censoEscola.Ano }, censoEscola);
        }

        // DELETE: api/CensoEscolas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CensoEscola>> DeleteCensoEscola(int id)
        {
            var censoEscola = await _context.CensosEscolas.FindAsync(id);
            if (censoEscola == null)
            {
                return NotFound();
            }

            _context.CensosEscolas.Remove(censoEscola);
            await _context.SaveChangesAsync();

            return censoEscola;
        }

        private bool CensoEscolaExists(int id)
        {
            return _context.CensosEscolas.Any(e => e.Ano == id);
        }
    }
}
