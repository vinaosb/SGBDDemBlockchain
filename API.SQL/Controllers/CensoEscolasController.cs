﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.SQL.Models;

namespace API.SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CensoEscolasController : ControllerBase
    {
        private readonly postgresContext _context;

        public CensoEscolasController(postgresContext context)
        {
            _context = context;
        }

        // GET: api/CensoEscolas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CensoEscola>>> GetCensoEscola()
        {
            return await _context.CensoEscola.ToListAsync();
        }

        // GET: api/CensoEscolas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CensoEscola>> GetCensoEscola(short id)
        {
            var censoEscola = await _context.CensoEscola.FindAsync(id);

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
        public async Task<IActionResult> PutCensoEscola(short id, CensoEscola censoEscola)
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
            _context.CensoEscola.Add(censoEscola);
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

            return CreatedAtAction("GetCensoEscola", new { id = censoEscola.Ano }, censoEscola);
        }

        // DELETE: api/CensoEscolas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CensoEscola>> DeleteCensoEscola(short id)
        {
            var censoEscola = await _context.CensoEscola.FindAsync(id);
            if (censoEscola == null)
            {
                return NotFound();
            }

            _context.CensoEscola.Remove(censoEscola);
            await _context.SaveChangesAsync();

            return censoEscola;
        }

        private bool CensoEscolaExists(short id)
        {
            return _context.CensoEscola.Any(e => e.Ano == id);
        }
    }
}
