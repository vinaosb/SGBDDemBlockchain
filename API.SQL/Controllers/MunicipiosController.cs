using API.SQL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.SQL.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MunicipiosController : ControllerBase
	{
		private readonly postgresContext _context;

		public MunicipiosController(postgresContext context)
		{
			_context = context;
		}

		// GET: api/Municipios
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipio()
		{
			return await _context.Municipio.ToListAsync();
		}

		// GET: api/Municipios/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Municipio>> GetMunicipio(long id)
		{
			var municipio = await _context.Municipio.FindAsync(id);

			if (municipio == null)
			{
				return NotFound();
			}

			return municipio;
		}

		// PUT: api/Municipios/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMunicipio(long id, Municipio municipio)
		{
			if (id != municipio.CodMunicipio)
			{
				return BadRequest();
			}

			_context.Entry(municipio).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MunicipioExists(id))
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

		// POST: api/Municipios
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see https://aka.ms/RazorPagesCRUD.
		[HttpPost]
		public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
		{
			_context.Municipio.Add(municipio);
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				if (MunicipioExists(municipio.CodMunicipio))
				{
					return Conflict();
				}
				else
				{
					throw;
				}
			}

			return CreatedAtAction("GetMunicipio", new { id = municipio.CodMunicipio }, municipio);
		}

		// DELETE: api/Municipios/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<Municipio>> DeleteMunicipio(long id)
		{
			var municipio = await _context.Municipio.FindAsync(id);
			if (municipio == null)
			{
				return NotFound();
			}

			_context.Municipio.Remove(municipio);
			await _context.SaveChangesAsync();

			return municipio;
		}

		private bool MunicipioExists(long id)
		{
			return _context.Municipio.Any(e => e.CodMunicipio == id);
		}
	}
}
